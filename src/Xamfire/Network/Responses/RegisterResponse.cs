using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Responses
{
    internal class RegisterResponse
    {
        public string Kind { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string LocalId { get; set; }
    }
}
