using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Xamfire.Contexts.Configurations
{
    public interface IModelConfiguration<TModel>
    {
        IModelConfiguration<TModel> SetPropertyName<TProperty>(Expression<Func<TProperty>> property, string firebaseFieldName);
        IModelConfiguration<TModel> SetDocumentPath(string path);

        string DocumentPath { get; }
        IDictionary<string, string> PropertiesMappings { get; }
        
    }
}
