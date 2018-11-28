using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts.Configurations;
using Xamfire.Json.Serializer.Default;

namespace Xamfire.Contexts.Builders
{
    public class DocumentModelBuilder<TModel> : IDocumentModelBuilder<TModel>
    {
        private readonly IJsonSerializer _jsonSerializer;
        private IModelConfiguration<TModel> _modelConfiguration;

        public IDocumentModelBuilder<TModel> SetModelConfiguration(IModelConfiguration<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;
            return this;
        }

        public string BuildFirebaseDocument(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
