using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamfire.Extensions;

namespace Xamfire.Document.Configurations
{
    public class ModelConfiguration<TModel> : IDocumentConfiguration<TModel>
    {
        public string DocumentPath { get; private set; }
        public IDictionary<string, string> PropertiesMappings { get; private set; }
        public string PrimaryKeyPropertyName { get; private set; }

        public ModelConfiguration()
        {
            PropertiesMappings = new Dictionary<string, string>();
        }

        public IDocumentConfiguration<TModel> SetDocumentPath(string path)
        {
            DocumentPath = path;
            return this;
        }

        public IDocumentConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> property, string firebaseFieldName)
        {
            var propertyName = property.GetMemberInfo().Name;
            PropertiesMappings.Add(propertyName, firebaseFieldName);
            return this;
        }

        public IDocumentConfiguration<TModel> SetPrimaryKey<TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            PrimaryKeyPropertyName = property.GetMemberInfo().Name;
            return this;
        }
    }
}
