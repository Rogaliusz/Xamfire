using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Json.Serializer.ContractResolver
{
    public class CamelCaseContractResolver : XamfireContractResolver
    {
        public override IDictionary<string, string> PropertMappings { get; internal set; }

        public CamelCaseContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }
    }
}
