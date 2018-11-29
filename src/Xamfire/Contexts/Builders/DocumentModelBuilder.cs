using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts.Configurations;
using Xamfire.Json.Serializer.Default;
using Xamfire.Json.Serializer.Document;

namespace Xamfire.Contexts.Builders
{
    public class DocumentModelBuilder<TModel> : IDocumentModelBuilder<TModel>
    {
        private readonly IJsonDocumentSerializer _jsonDocumentSerializer;
        private IModelConfiguration<TModel> _modelConfiguration;

        public DocumentModelBuilder(IJsonDocumentSerializer jsonDocumentSerializer)
        {
            _jsonDocumentSerializer = jsonDocumentSerializer;
        }

        public IDocumentModelBuilder<TModel> SetModelConfiguration(IModelConfiguration<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;
            return this;
        }

        public string BuildFirebaseDocument(TModel model)
        {
            var customProperiesMappings = _modelConfiguration.PropertiesMappings;

            return _jsonDocumentSerializer.SetCustomPropertiesMappings(customProperiesMappings)
                .Serialize(model);
        }
    }
}
