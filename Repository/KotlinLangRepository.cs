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
                var book = new BookIntegration()
                {
                    URL = urls[item].Attributes.AttributesWithName("href").First().Value,
                    Title = titles[item].InnerHtml,
                    Language = langs[item].InnerHtml
                };

                if (book.URL.Last().Equals('/'))
                    book.URL = book.URL.Substring(0, book.URL.Length - 1);

                book.Description = descs[item + (item.Equals(0) ? 0 : 2)].InnerHtml;
                book.Description = book.Description.Replace(book.URL, "").Replace("<a href=\"\">", "").Replace("</a>", "");

                list.Add(book);
            }

            return list;
        }
    }
}
