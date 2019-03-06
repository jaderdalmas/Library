using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repository
{
    public class KotlinLangRepository : BaseRepository, IKotlinLangRepository
    {
        public string Unavailable { get { return "Unavailable"; } }

        public KotlinLangRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<BookIntegration>> GetBooks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(KotlinLangSite);

            HtmlDocument doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync(""));

            var urls = doc.DocumentNode.SelectNodes("//article/a");
            var titles = doc.DocumentNode.SelectNodes("//article/h2");
            var langs = doc.DocumentNode.SelectNodes("//article/div");
            var descs = doc.DocumentNode.SelectNodes("//article/p");

            List<BookIntegration> list = new List<BookIntegration>();
            for (int item = 0; item < urls.Count; item++)
            {
                var url = urls[item].GetAttributeValue("href", "").Trim();
                if (url.Last().Equals('/')) { url = url.Substring(0, url.Length - 1); }

                var desc = descs[item + (item.Equals(0) ? 0 : 2)].InnerHtml.Trim();
                desc = desc.Replace(url, "").Replace("<a href=\"\">", "").Replace("<a href=\"/\">", "").Replace("</a>", "");

                var book = new BookIntegration()
                {
                    URL = url,
                    ISBN = await GetISBN(url),
                    Title = titles[item].InnerHtml.Trim(),
                    Description = desc.Trim(),
                    Language = langs[item].InnerHtml.Trim()
                };

                list.Add(book);
            }

            return list;
        }

        #region ISBN 

        public async Task<string> GetISBN(string url)
        {
            if (url.StartsWith("https://www.amazon") // Crypt
             || url.StartsWith("http://www.fundamental-kotlin.com") // 500
             || url.StartsWith("https://kotlinandroidbook.com") // No ISBN
             || url.StartsWith("https://leanpub.com") // No ISBN
             || url.StartsWith("https://store.raywenderlich.com") // No ISBN
             || url.StartsWith("https://www.raywenderlich.com")) // No ISBN
            {
                return Unavailable;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            string html = "";
            try { html = await client.GetStringAsync(""); }
            catch (Exception ex) { html = ex.Message; }

            if (!string.IsNullOrWhiteSpace(html) &&
            (html.Contains("ISBN") || html.Contains("Stok Kodu")))
            {
                if (url.Contains("manning.com"))
                {
                    return GetManningCom(html);
                }
                else if (url.StartsWith("https://www.packtpub.com"))
                {
                    return GetPacktpubCom(html);
                }
                else if (url.StartsWith("https://www.kuramkitap.com"))
                {
                    return GetKuramkitapCom(html);
                }
                else if (url.StartsWith("https://www.editions-eni.fr"))
                {
                    return GetEditionsEniFr(html);
                }
            }

            return Unavailable;
        }

        private string GetManningCom(string html)
        {
            return html.Substring(html.IndexOf("ISBN") + 4, 15).Trim();
        }

        private string GetPacktpubCom(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode.SelectNodes("//@isbn").First().GetAttributeValue("isbn", "");
        }

        private string GetEditionsEniFr(string html)
        {
            return html.Substring(html.IndexOf("ISBN") + 4, 20).Replace(":", "").Replace("-", "").Trim();
        }

        private string GetKuramkitapCom(string html)
        {
            return html.Substring(html.IndexOf("Stok Kodu") + 70, 13).Trim();
        }

        #endregion
    }
}
