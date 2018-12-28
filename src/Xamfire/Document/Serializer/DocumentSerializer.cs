using Newtonsoft.Json;
using Xamfire.Document.ContractResolver;

namespace Xamfire.Document.Serializer
{
    public class DocumentSerializer : IDocumentSerializer
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

        public IDocumentSerializer SetContractResolver(XamfireContractResolver xamfireContractResolver)
        {
            _contractResolver = xamfireContractResolver;

            return this;
        }
    }
}
