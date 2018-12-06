using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Json.Serializer.ContractResolver;

namespace Xamfire.Json.Serializer.Document
{
    public class JsonDocumentSerializer : IJsonDocumentSerializer
    {
        private JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            ContractResolver = _contractResolver,
            Formatting = Formatting.Indented
        };

        private XamfireContractResolver _contractResolver;

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }

        public string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model, JsonSettings);
        }

        public IJsonDocumentSerializer SetContractResolver(XamfireContractResolver xamfireContractResolver)
        {
            _contractResolver = xamfireContractResolver;

            return this;
        }
    }
}
