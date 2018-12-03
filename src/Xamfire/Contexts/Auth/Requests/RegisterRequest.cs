using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Contexts.Auth.Requests
{
    internal class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; }

        public RegisterRequest(string email, string password, bool returnSecureToken)
        {
            Email = email;
            Password = password;
            ReturnSecureToken = returnSecureToken;
        }
    }
}
