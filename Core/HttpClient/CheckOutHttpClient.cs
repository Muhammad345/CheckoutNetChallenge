using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheckOutCore.Domain;
using CheckOutCore.AcquiringSettings;
using CheckOutCore.Constant;

namespace CheckOutCore.Client
{
    public class CheckOutHttpClient : IHttpClient
    {
        private readonly CheckOutSettings _checkOutSettings;
        private readonly HttpClient _client = new HttpClient();

        public CheckOutHttpClient(IOptions<CheckOutSettings> options)
        {
            _checkOutSettings = options.Value;
        }
        public async Task<Tout> Post<TIn,Tout>(string endPoint, TIn content) where Tout : new()
        {
            var response = new HttpResponseMessage();
            dynamic modularHttpClientResponse;

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, GetUrl(endPoint));
                AddHttpHeader(httpRequestMessage);

                if (content != null)
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    };

                    var json = JsonConvert.SerializeObject(content, jsonSettings);
                    httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, CheckOutHttpClientConstant.ContentType.Application_Json);
                }

                response = await _client.SendAsync(httpRequestMessage);

                if(response.IsSuccessStatusCode)
                {
                    modularHttpClientResponse = await GenerateSuccessResponse(response);
                    return (Tout)modularHttpClientResponse;
                }

               
                modularHttpClientResponse = await GenerateBadRequestErrorResponse(response);
                return (Tout)modularHttpClientResponse;
            }
            catch (Exception exp)
            {
                modularHttpClientResponse = await GenerateErrorResponse(response, exp);

                return (Tout)modularHttpClientResponse;
            }
        }

        public async Task<T> Get<T>(string endPoint) where T : new()
        {
            var response = new HttpResponseMessage();
            dynamic modularHttpClientResponse;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, GetUrl(endPoint));
                AddHttpHeader(request);
                response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    modularHttpClientResponse = await GenerateSuccessResponse(response);
                    return (T)modularHttpClientResponse;
                }

                modularHttpClientResponse = await GenerateBadRequestErrorResponse(response);
                return (T)modularHttpClientResponse;
            }
            catch (Exception exp)
            {

                modularHttpClientResponse = await GenerateErrorResponse(response, exp);

                return (T)modularHttpClientResponse;
            }
        }

        public async Task<Tout> Delete<TIn, Tout>(string endPoint, TIn content) where Tout : new()
        {
            var response = new HttpResponseMessage();
            dynamic modularHttpClientResponse;

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, GetUrl(endPoint));
                AddHttpHeader(httpRequestMessage);

                if (content != null)
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    };

                    var json = JsonConvert.SerializeObject(content, jsonSettings);
                    httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, CheckOutHttpClientConstant.ContentType.Application_Json);
                }

                response = await _client.SendAsync(httpRequestMessage);
                var data = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    modularHttpClientResponse = await GenerateSuccessResponse(response);
                    return (Tout)modularHttpClientResponse;
                }

                modularHttpClientResponse = await GenerateBadRequestErrorResponse(response);
                return (Tout)modularHttpClientResponse;
            }
            catch (Exception exp)
            {
                modularHttpClientResponse = await GenerateErrorResponse(response, exp);

                return (Tout)modularHttpClientResponse;
            }
        }

        public void AddHttpHeader(HttpRequestMessage httpRequest)
        {
            foreach (var item in GetHttpHeader())
            {
                if(!string.IsNullOrWhiteSpace(item.Value))
                {
                    httpRequest.Headers.Add(item.Key, item.Value);
                }
            }
        }

        public Dictionary<string, string> GetHttpHeader()
        {
            var date = DateTime.UtcNow.ToString("r");
            var nonce = Guid.NewGuid();
            var signatureString = $"{CheckOutHttpClientConstant.Header.Date.ToLower()}: {date}\n";
               signatureString += $"{ CheckOutHttpClientConstant.Header.XModNonce.ToLower()}: {nonce}";

            var Headers = new Dictionary<string, string>
            {
                { CheckOutHttpClientConstant.Header.Date, date },
                { CheckOutHttpClientConstant.Header.XModNonce, nonce.ToString() },
              //  { ModulrHttpClientConstant.Header.Authorization,GetAuthorizationHeader(_signatures.CreateSignature(signatureString))},
                { CheckOutHttpClientConstant.Header.Accept, CheckOutHttpClientConstant.ContentType.Application_Json}
            };

            return Headers;
        }

        private string GetAuthorizationHeader(string urlEncodedBase64Signature)
        {
            var sb = new StringBuilder();
            sb.Append($"{CheckOutHttpClientConstant.Security.SignaturekeyId}=\"{ _checkOutSettings.ApiKey }\",");
            sb.Append($"{CheckOutHttpClientConstant.Security.Algorithm}=\"{ CheckOutHttpClientConstant.Security.HmacSha1}\",");
            sb.Append($"{CheckOutHttpClientConstant.Security.Headers}=\"{ CheckOutHttpClientConstant.Header.Date.ToLower()} { CheckOutHttpClientConstant.Header.XModNonce.ToLower()}\",");
            sb.Append($"{CheckOutHttpClientConstant.Security.Signature}=\"{ urlEncodedBase64Signature}\"");

            return sb.ToString();
        }

        private string GetUrl(string endPoint)
        {
            return $"{_checkOutSettings.Url}{endPoint}";
        }

        private async Task<CheckOutHttpClientResponse> GenerateSuccessResponse(HttpResponseMessage httpResponseMessage)
        {
            return   new CheckOutHttpClientResponse
            {
                IsSuccessFull = httpResponseMessage.IsSuccessStatusCode,
                Data = await httpResponseMessage.Content.ReadAsStringAsync(),
                StatusCode = httpResponseMessage.StatusCode
            };
        }

        private async Task<CheckOutHttpClientResponse> GenerateErrorResponse(HttpResponseMessage httpResponseMessage, Exception exception)
        {
            var data = await httpResponseMessage.Content.ReadAsStringAsync();

            return new CheckOutHttpClientResponse
            {
                IsSuccessFull = httpResponseMessage.IsSuccessStatusCode,
                Data = data,
                StatusCode = httpResponseMessage.StatusCode,
                Error = JsonConvert.DeserializeObject<List<CheckOutError>>(data),
                Exception = exception
            };
        }


        private async Task<CheckOutHttpClientResponse> GenerateBadRequestErrorResponse(HttpResponseMessage httpResponseMessage)
        {
            var data = await httpResponseMessage.Content.ReadAsStringAsync();

            return new CheckOutHttpClientResponse
            {
                IsSuccessFull = httpResponseMessage.IsSuccessStatusCode,
                Data = data,
                StatusCode = httpResponseMessage.StatusCode,
                Error = JsonConvert.DeserializeObject<List<CheckOutError>>(data),
            };
        }
    }
}

