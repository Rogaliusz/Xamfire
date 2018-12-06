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
            NamingStrategy = new CamelCaseNamingStrategy();

            _modelConfiguration = modelConfiguration;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {   
            var property =  base.CreateProperty(member, memberSerialization);
            var primaryKeyName = _modelConfiguration.PrimaryKeyPropertyName;
            
            if (primaryKeyName == member.Name)
            {
                property.Ignored = true;
            } 
            else if (_modelConfiguration.PropertiesMappings.ContainsKey(member.Name))
            {
                property.PropertyName = _modelConfiguration.PropertiesMappings[member.Name];
            }

            return property;
        }
    }
}
