using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamfire.Contexts.Configurations;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Settings;
using Xamfire.Extensions;
using Xamfire.Json.Serializer.ContractResolver;
using Xamfire.Json.Serializer.Default;
using Xamfire.Json.Serializer.Document;
using Xamfire.Settings;

namespace Xamfire.Contexts.Builders
{
    public class DocumentModelBuilder<TModel> : IDocumentModelBuilder<TModel>
    {
        private readonly IJsonDocumentSerializer _jsonDocumentSerializer;
        private readonly IFirebaseSettings _firebaseSettings;

        private IModelConfiguration<TModel> _modelConfiguration;

        public DocumentModelBuilder(IJsonDocumentSerializer jsonDocumentSerializer, IFirebaseSettings firebaseSettings)
        {
            _jsonDocumentSerializer = jsonDocumentSerializer;
            _firebaseSettings = firebaseSettings;
        }

        public IDocumentModelBuilder<TModel> SetModelConfiguration(IModelConfiguration<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;

            return this;
        }

        public string BuildFirebaseDocument(TModel model)
        {
            var dict = new Dictionary<string, object>() { { "modelConfiguration", _modelConfiguration } };
            var ctrParams = new NamedParameterOverloads(dict);
            var contractResolver = IoC.MainContainer.ResolveInstance<DocumentContractResolver<TModel>>(ctrParams);

            return _jsonDocumentSerializer.SetContractResolver(contractResolver)
                .Serialize(model);
        }

        public string GetDocumentPath(TModel model)
        {
            if (_modelConfiguration.PrimaryKeyPropertyName.IsEmpty())
                throw new InvalidConfigException(ExceptionMessages.PRIMARY_KEY_WAS_NOT_SET);

            var primaryKey = typeof(TModel)
                .GetProperty(_modelConfiguration.PrimaryKeyPropertyName)
                .GetValue(model);

            return $"{_firebaseSettings.Url}/{_modelConfiguration.DocumentPath}/{primaryKey}.json/?auth={_firebaseSettings.UserToken}";
        }

        public string GetDocumentPath()
        {
            return $"{_firebaseSettings.Url}/{_modelConfiguration.DocumentPath}.json/?auth={_firebaseSettings.UserToken}";
        }
    }
}
