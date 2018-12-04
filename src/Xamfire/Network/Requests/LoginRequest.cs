using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Requests
{
    internal class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; }

        public LoginRequest(string email, string password, bool returnSecureToken)
        {
            Email = email;
            Password = password;
            ReturnSecureToken = returnSecureToken;
        }
    }
}
