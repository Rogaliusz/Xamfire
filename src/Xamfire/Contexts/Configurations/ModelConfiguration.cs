using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamfire.Extensions;

namespace Xamfire.Contexts.Configurations
{
    public class ModelConfiguration<TModel> : IModelConfiguration<TModel>
    {
        public string DocumentPath { get; private set; }

        public IDictionary<string, string> PropertiesMappings { get; private set; }

        public ModelConfiguration()
        {
            PropertiesMappings = new Dictionary<string, string>();
        }

        public IModelConfiguration<TModel> SetDocumentPath(string path)
        {
            DocumentPath = path;
            return this;
        }

        public IModelConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> property, string firebaseFieldName)
        {
            var propertyName = property.GetMemberInfo().Name;
            PropertiesMappings.Add(propertyName, firebaseFieldName);
            return this;
        }
    }
}
