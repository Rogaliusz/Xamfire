using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Xamfire.Json.Serializer.ContractResolver
{
    public abstract class XamfireContractResolver : DefaultContractResolver
    {
        public abstract IDictionary<string, string> PropertMappings { get; internal set; } 

        protected override string ResolvePropertyName(string propertyName)
        {
            var resolved = this.PropertMappings.TryGetValue(propertyName, out string resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
