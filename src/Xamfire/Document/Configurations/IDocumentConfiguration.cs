using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Xamfire.Document.Configurations
{
    public interface IDocumentConfiguration<TModel>
    {
        string DocumentPath { get; }
        string PrimaryKeyPropertyName { get; }

        IEnumerable<IChildDocumentConfiguration<TModel, object>> Childrens { get; }
        IReadOnlyDictionary<string, string> PropertiesMappings { get; }

        IDocumentConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> property, string firebaseFieldName);
        IDocumentConfiguration<TModel> SetDocumentPath(string path);
        IDocumentConfiguration<TModel> SetPrimaryKey<TProperty>(Expression<Func<TModel, TProperty>> property);

        IChildDocumentConfiguration<TModel, TChildModel> SetupChildConfiguration<TChildModel>(Expression<Func<TModel, TChildModel>> property);
    }
}
