using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Requests
{
    internal class RegisterRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("returnSecureToken")]
        public bool ReturnSecureToken { get; set; }

        public RegisterRequest(string email, string password, bool returnSecureToken)
        {
            Email = email;
            Password = password;
            ReturnSecureToken = returnSecureToken;
        }
    }
}
