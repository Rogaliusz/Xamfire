using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamfire.Json.Serializer.Document;
using Xamfire.Network.Responses;

namespace Xamfire.Network.Service
{
    public class NetworkService : INetworkService
    {
        private const string JSON_HEADER = "application/json";

        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly NativeMessageHandler _nativeMessageHandler = new NativeMessageHandler();

        private readonly IJsonDocumentSerializer _jsonDocumentSerializer;

        public NetworkService(IJsonDocumentSerializer jsonDocumentSerializer)
        {
            _jsonDocumentSerializer = jsonDocumentSerializer;
        }

        public async Task<string> GetAsync(string address)
        {
            var response = await _httpClient.GetAsync(address);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task PostAsync(string address, string json)
        {
            await PostAsync<object>(address, json);
        }

        public async Task<TModel> PostAsync<TModel>(string address, object model)
            => await PostAsync<TModel>(address, _jsonDocumentSerializer.Serialize(model));

        public async Task<TModel> PostAsync<TModel>(string address, string json)
        {
            var response = await _httpClient.PostAsync(address, GetPayload(json));
            return await TranslateResponse<TModel>(response);
        }

        public async Task PutAsync(string address, string json)
        {
            await PutAsync<object>(address, json);
        }

        public async Task<TResponse> PutAsync<TResponse>(string address, object model)
        {
            return await PutAsync<TResponse>(address, _jsonDocumentSerializer.Serialize(model));
        }

        public async Task<TResponse> PutAsync<TResponse>(string address, string json)
        {
            var response = await _httpClient.PutAsync(address, GetPayload(json));
            return await TranslateResponse<TResponse>(response);
        }

        private async Task<TModel> TranslateResponse<TModel>(HttpResponseMessage response)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            var model = _jsonDocumentSerializer.Deserialize<TModel>(responseJson);

            if (model is BaseResponse res)
            {
                res.StatusCode = (int)response.StatusCode;
            }

            return model;
        }

        public async Task DeleteAsync(string address)
        {
            var response = await _httpClient.DeleteAsync(address);
        }

        private HttpContent GetPayload(string json)
        {
            return new StringContent(json, Encoding.UTF8, JSON_HEADER);
        }

        public Task<TModel> GetAsync<TModel>(string address)
        {
            throw new NotImplementedException();
        }


        public Task DeleteAsync<TResponse>(string address)
        {
            throw new NotImplementedException();
        }
    }
}
