using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SampleStatelessWebApi.Tests.TestSupport.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient AddBasicAuthentication(this HttpClient httpClient, string username, string password)
        {
            var seed = $"{username}:{password}";
            var token = ToBase64(seed);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            return httpClient;
        }

        private static string ToBase64(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            var textBase64 = Convert.ToBase64String(textBytes);
            return textBase64;
        }
    }
}
