using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Responses
{
    internal class LoginResponse
    {
        public string Kind { get; set; }

        public string IdToken { get; set; }

        public string Email { get; set; }

        public string RefreshToken { get; set; }

        public string ExpiresIn { get; set; }

        public string LocalId { get; set; }

        public bool Registered { get; set; }
    }
}
