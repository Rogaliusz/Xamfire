using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamfire.Network.Service
{
    public interface INetworkService
    {
        Task<string> GetAsync(string address);
        Task<TModel> GetAsync<TModel>(string address);

        Task PostAsync(string address, string json);
        Task<TResponse> PostAsync<TResponse>(string address, object model);
        Task<TResponse> PostAsync<TResponse>(string address, string json);

        Task PutAsync(string address, string json);
        Task<TResponse> PutAsync<TResponse>(string address, object model);
        Task<TResponse> PutAsync<TResponse>(string address, string json);

        Task DeleteAsync<TResponse>(string address);
    }
}
