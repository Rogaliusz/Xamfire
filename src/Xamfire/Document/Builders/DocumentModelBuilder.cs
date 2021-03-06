using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TinyIoC;
using Xamfire.Document.Configurations;
using Xamfire.Document.ContractResolver;
using Xamfire.Document.Serializer;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Settings;
using Xamfire.Extensions;
using Xamfire.Settings;

namespace Xamfire.Document.Builders
{
    public class DocumentModelBuilder<TModel> : IDocumentModelBuilder<TModel>
    {
        private readonly IDocumentSerializer _jsonDocumentSerializer;
        private readonly IFirebaseSettings _firebaseSettings;

        private IDocumentConfiguration<TModel> _modelConfiguration;

        public DocumentModelBuilder(IDocumentSerializer jsonDocumentSerializer, IFirebaseSettings firebaseSettings)
        {
            _jsonDocumentSerializer = jsonDocumentSerializer;
            _firebaseSettings = firebaseSettings;
        }

        public IDocumentModelBuilder<TModel> SetModelConfiguration(IDocumentConfiguration<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;

            return this;
        }

        public TModel BuildModel(string document, string address)
        {
            var contractResolver = GetContractResolver();
            var model = _jsonDocumentSerializer.SetContractResolver(contractResolver)
                .Deserialize<TModel>(document);

            var id = GetId(address);
            if(id != null && model != null)
            {
                SetIdToModel(id, model);
            }

            return model;
        }

        private string GetId(string address)
        {
            var regexPattern = new Regex("/.[^/]*.json");

            if (regexPattern.IsMatch(address))
            {
                var match = regexPattern.Match(address);
                var beforeConvert = match.Value;
                return beforeConvert.Substring(1).Replace(".json", "");
            }

            return null;
        }

        private void SetIdToModel(string id, TModel model)
        {
            var property = typeof(TModel).GetProperty(_modelConfiguration.PrimaryKeyPropertyName);

            if (property.PropertyType == typeof(Guid))
            {
                property.SetValue(model, new Guid(id));
            } 
            else if (property.PropertyType == typeof(int))
            {
                property.SetValue(model, int.Parse(id));
            }
            else if (property.PropertyType == typeof(string))
            {
                property.SetValue(model, id);
            }
        }

        public string BuildFirebaseDocument(TModel model)
        {
            var contractResolver = GetContractResolver();

            return _jsonDocumentSerializer.SetContractResolver(contractResolver)
                .Serialize(model);
        }

        private DocumentContractResolver<TModel> GetContractResolver()
        {
            var dict = new Dictionary<string, object>() { { "modelConfiguration", _modelConfiguration } };
            var ctrParams = new NamedParameterOverloads(dict);
            var contractResolver = IoC.MainContainer.ResolveInstance<DocumentContractResolver<TModel>>(ctrParams);
            return contractResolver;
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

        public string GetDocumentPath(object key)
        {
            return $"{_firebaseSettings.Url}/{_modelConfiguration.DocumentPath}/{key}.json/?auth={_firebaseSettings.UserToken}";
        }

        public string GetDocumentPath()
        {
            return $"{_firebaseSettings.Url}/{_modelConfiguration.DocumentPath}.json/?auth={_firebaseSettings.UserToken}";
        }
    }
}
