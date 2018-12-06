using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Json.Serializer.ContractResolver;
using Xamfire.Json.Serializer.Default;

namespace Xamfire.Json.Serializer.Document
{
    public interface IJsonDocumentSerializer : IJsonSerializer
    {
        IJsonDocumentSerializer SetContractResolver(XamfireContractResolver xamfireContractResolver);

    }
}
