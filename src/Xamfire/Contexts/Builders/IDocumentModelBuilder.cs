using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts.Configurations;

namespace Xamfire.Contexts.Builders
{
    public interface IDocumentModelBuilder<TModel>
    {
        IDocumentModelBuilder<TModel> SetModelConfiguration(IModelConfiguration<TModel> modelConfiguration);
        string BuildFirebaseDocument(TModel model);
        TModel BuildModel(string document, string address);
        string GetDocumentPath();
        string GetDocumentPath(object key);
        string GetDocumentPath(TModel model);
    }
}
