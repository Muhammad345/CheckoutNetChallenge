using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckOutCore.Client
{
    public interface IHttpClient
    {
        void AddHttpHeader(HttpRequestMessage httpRequest);

        Dictionary<string, string> GetHttpHeader();

        Task<T> Get<T>(string url) where T : new();

        Task<Tout> Post<TIn, Tout>(string uri, TIn content) where Tout : new();

        Task<Tout> Delete<TIn, Tout>(string endPoint, TIn content) where Tout : new();

    }
}
