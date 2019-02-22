using HtmlAgilityPack;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repository
{
    public class KotlinLangRepository
    {
        public async Task<IEnumerable<BookIntegration>> GetBooks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://kotlinlang.org/docs/books.html");

            HtmlDocument doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync(""));

            var urls = doc.DocumentNode.SelectNodes("//article/a");
            var titles = doc.DocumentNode.SelectNodes("//article/h2");
            var langs = doc.DocumentNode.SelectNodes("//article/div");
            var descs = doc.DocumentNode.SelectNodes("//article/p");

            List<BookIntegration> list = new List<BookIntegration>();
            for (int item = 0; item < urls.Count; item++)
            {
                var url = urls[item].Attributes.AttributesWithName("href").First().Value.Trim();
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

        public async Task<long> GetISBN(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            string html = "";
            try { html = await client.GetStringAsync(""); }
            catch (Exception ex) { html = ex.Message; }

            if (!string.IsNullOrWhiteSpace(html) && html.Contains("ISBN"))
            {
                int isbnIndex = html.LastIndexOf("ISBN");

                var partial = html.Substring(html.IndexOf("ISBN") + 4, 50).Replace("-", "").Replace(":", "");

                var init = partial.LastIndexOf('>');
                var end = partial.LastIndexOf('<');
                if (init > end) { init = -1; end = partial.IndexOf('<'); }
                if (end > 0) { partial = partial.Substring(init + 1, end - init - 1); }

                return long.Parse(partial.Trim());

                //Stok Kodu
            }

            return 0;
        }
    }
}
