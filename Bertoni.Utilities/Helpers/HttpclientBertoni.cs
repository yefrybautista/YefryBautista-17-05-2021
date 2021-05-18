using Bertoni.Contracts.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Utilities.Helpers
{
    public class HttpclientBertoni : IHttpclientBertoni
    {
        HttpClient _client;
        public HttpclientBertoni()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public void SetToken(string token)
        {
            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        public Task<string> PostXml(string url, string body)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostObject(string url, string body)
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetAsync(string url)
        {
            var responseMessage = await _client.GetAsync(url);

            string stringJSON = responseMessage.Content.ReadAsStringAsync().Result;

            return stringJSON;
        }
    }
}
