using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Contracts.Helpers
{
    public interface IHttpclientBertoni
    {
        void SetToken(string token);
        Task<string> PostXml(string url, string body);
        Task<HttpResponseMessage> PostObject(string url, string body);
        Task<string> GetAsync(string url);
    }
}
