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

        private readonly XamfireContractResolver _contractResolver;

        public JsonDocumentSerializer(XamfireContractResolver contractResolver)
        {
            _contractResolver = contractResolver;
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }

        public string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model, JsonSettings);
        }

        public IJsonDocumentSerializer SetCustomPropertiesMappings(IDictionary<string, string> propertiesMappings)
        {
            _contractResolver.PropertMappings = propertiesMappings;
            return this;
        }
    }
}
