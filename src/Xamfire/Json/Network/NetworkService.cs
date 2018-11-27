using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xamfire.Network
{
    public class NetworkService : INetworkService
    {
        private static readonly HttpClient _httpClient = new HttpClient(_nativeMessageHandler);
        protected static readonly NativeMessageHandler _nativeMessageHandler = new NativeMessageHandler();

        public async Task<string> GetAsync(string address)
        {
            var response = await _httpClient.GetAsync(address);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task PostAsync(string address, string json)
        {
            var response = await _httpClient.PostAsync(address, GetPayload(json));
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
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
