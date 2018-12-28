using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamfire.Document.Configurations;

namespace Xamfire.Document.ContractResolver
{
    public class DocumentContractResolver<TModel> : XamfireContractResolver
    {
        private IDocumentConfiguration<TModel> _modelConfiguration;

        public DocumentContractResolver(IDocumentConfiguration<TModel> modelConfiguration)
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
