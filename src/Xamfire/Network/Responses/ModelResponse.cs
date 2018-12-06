using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Network.Responses
{
    internal class ModelResponse<TModel> : BaseResponse
    {
        [JsonProperty("")]
        public TModel Model { get; set; }
    }
}
