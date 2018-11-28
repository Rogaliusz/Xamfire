using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Json.Serializer.ContractResolver
{
    public class SnakeCaseContractResolver : XamfireContractResolver
    {
        public override IDictionary<string, string> PropertMappings { get; internal set; }

        public SnakeCaseContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy();
        }
    }
}
