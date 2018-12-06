using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Responses
{
    internal class RegisterResponse : BaseResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("idToken")]
        public string IdToken { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }
        [JsonProperty("localId")]
        public string LocalId { get; set; }
    }
}
