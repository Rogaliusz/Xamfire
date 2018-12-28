using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamfire.Extensions;

namespace Xamfire.Document.Configurations
{
    public class DocumentConfiguration<TModel> : IDocumentConfiguration<TModel>
    {
        private readonly IList<IChildDocumentConfiguration<TModel, object>> _childrens;
        private readonly Dictionary<string, string> _propertiesMappings;

        public string DocumentPath { get; private set; }
        public string PrimaryKeyPropertyName { get; private set; }

        public IReadOnlyDictionary<string, string> PropertiesMappings => _propertiesMappings;
        public IEnumerable<IChildDocumentConfiguration<TModel, object>> Childrens => _childrens;

        public DocumentConfiguration()
        {
            _childrens = new List<IChildDocumentConfiguration<TModel, object>>();
            _propertiesMappings = new Dictionary<string, string>();
        }

        public IDocumentConfiguration<TModel> SetDocumentPath(string path)
        {
            DocumentPath = path;
            return this;
        }

        public IDocumentConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> property, string firebaseFieldName)
        {
            var propertyName = property.GetMemberInfo().Name;
            _propertiesMappings.Add(propertyName, firebaseFieldName);
            return this;
        }

        public IDocumentConfiguration<TModel> SetPrimaryKey<TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            PrimaryKeyPropertyName = property.GetMemberInfo().Name;
            return this;
        }

        public IChildDocumentConfiguration<TModel, TChildModel> SetupChildConfiguration<TChildModel>(Expression<Func<TModel, TChildModel>> property)
        {
            var childName = property.GetMemberInfo().Name;
            var childDocumentConfiguration = new ChildDocumentConfiguration<TModel, TChildModel>(this, childName);

            return childDocumentConfiguration;
        }
    }
}
