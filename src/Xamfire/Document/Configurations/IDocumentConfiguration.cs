using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Xamfire.Document.Configurations
{
    public interface IDocumentConfiguration<TModel>
    {
        IDocumentConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> property, string firebaseFieldName);
        IDocumentConfiguration<TModel> SetDocumentPath(string path);
        IDocumentConfiguration<TModel> SetPrimaryKey<TProperty>(Expression<Func<TModel, TProperty>> property);

        string DocumentPath { get; }
        IDictionary<string, string> PropertiesMappings { get; }
        string PrimaryKeyPropertyName { get; }
    }
}
