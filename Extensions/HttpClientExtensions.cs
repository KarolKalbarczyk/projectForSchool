using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASP_pl.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> Retry(this HttpClient httpClient, int retries, Func<Task<HttpResponseMessage>> func)
        {
            var tries = 0;
            while (tries++ < retries)
            {
                try
                {
                    var response = await func();
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch (HttpRequestException) when (tries < retries) { }
            }
            return null; //won't happen
        }
    }
}
