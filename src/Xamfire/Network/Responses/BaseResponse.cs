using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Responses
{
    internal abstract class BaseResponse
    {
        public bool IsSuccess => StatusCode == 200 || Error != null;

        public int StatusCode { get; set; }

        public string Message { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
