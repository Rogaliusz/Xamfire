using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamfire.Json.Serializer.Document;

namespace Xamfire.Json.Network
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
            await PostAsync<object>(address, GetPayload(json));
        }

        public async Task<TModel> PostAsync<TModel>(string address, object model)
            => await PostAsync<TModel>(address, _jsonDocumentSerializer.Serialize(model));

        public async Task<TModel> PostAsync<TModel>(string address, string json)
        {
            var response = await _httpClient.PostAsync(address, GetPayload(json));
            var responseJson = await response.Content.ReadAsStringAsync();
            return _jsonDocumentSerializer.Deserialize<TModel>(responseJson);
        }

        public async Task PutAsync(string address, string json)
        {
            var response = await _httpClient.PutAsync(address, GetPayload(json));
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
    }
}
