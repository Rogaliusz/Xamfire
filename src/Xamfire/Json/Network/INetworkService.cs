using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamfire.Network
{
    public interface INetworkService
    {
        Task<string> GetAsync(string address);
        Task PostAsync(string address, string json);
        Task PutAsync(string address, string json);
        Task DeleteAsync(string address);
    }
}
