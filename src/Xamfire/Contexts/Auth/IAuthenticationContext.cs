using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamfire.Contexts.Auth
{
    public interface IAuthenticationContext
    {
        Task RegisterUserAsync(string email, string password);
        Task LoginUserAsync(string email, string password);
    }
}
