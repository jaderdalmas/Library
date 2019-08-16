using Microsoft.AspNetCore.Http;
using System;

namespace Model.Extension
{
    public static class HttpRequestExtension
    {
        private static string GetUrl(this HttpRequest Request)
        {
            return $"{Request.Scheme}://{Request.Host}{Request.Path}";
        }

        public static Uri GetUri(this HttpRequest Request)
        {
            var referer = Request.Headers["Referer"].ToString();
            return new Uri(string.IsNullOrWhiteSpace(referer) ? GetUrl(Request) : referer);
        }
    }
}
