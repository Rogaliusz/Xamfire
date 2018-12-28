using Xamfire.Document.ContractResolver;

namespace Xamfire.Document.Serializer
{
    public interface IDocumentSerializer
    {
        IDocumentSerializer SetContractResolver(XamfireContractResolver xamfireContractResolver);

        TModel Deserialize<TModel>(string json);

        string Serialize<TModel>(TModel model);
    }
}
