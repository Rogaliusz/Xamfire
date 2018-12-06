using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamfire.Contexts.Configurations;

namespace Xamfire.Json.Serializer.ContractResolver
{
    public class DocumentContractResolver<TModel> : XamfireContractResolver
    {
        private IModelConfiguration<TModel> _modelConfiguration;

        public DocumentContractResolver(IModelConfiguration<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
           
            return base.CreateProperty(member, memberSerialization);
        }

        public override IDictionary<string, string> PropertMappings { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
    }
}
