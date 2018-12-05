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
        string GetDocumentPath(TModel model);
    }
}
