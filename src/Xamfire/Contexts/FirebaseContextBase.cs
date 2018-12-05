using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamfire.Contexts.Builders;
using Xamfire.Contexts.Configurations;
using Xamfire.IoC;
using Xamfire.Json.Serializer;
using Xamfire.Network.Service;
using Xamfire.Settings;

namespace Xamfire.Contexts
{
    public abstract class FirebaseContextBase<TModel> 
    {
        private readonly INetworkService _networkService;
        private readonly IFirebaseSettings _firebaseSettings;
        private readonly IModelConfiguration<TModel> _modelConfiguration;
        private readonly IDocumentModelBuilder<TModel> _documentModelBuilder;

        public FirebaseContextBase()
        {
            _networkService = MainContainer.ResolveInstance<INetworkService>();
            _firebaseSettings = MainContainer.ResolveInstance<IFirebaseSettings>();
            _modelConfiguration = MainContainer.ResolveInstance<IModelConfiguration<TModel>>();
            _documentModelBuilder = MainContainer.ResolveInstance<IDocumentModelBuilder<TModel>>();

            Configure(_modelConfiguration);

            _documentModelBuilder.SetModelConfiguration(_modelConfiguration);
        }

        public abstract void Configure(IModelConfiguration<TModel> modelConfiguration);

        public virtual async Task InsertOrUpdateAsync(TModel data)
        {
            var address = _documentModelBuilder.GetDocumentPath(data);
            var document = _documentModelBuilder.BuildFirebaseDocument(data);

            await _networkService.PutAsync(address, document);
        }

        private string GetUrl()
        {
            return $"{_firebaseSettings.Url}/{_modelConfiguration.DocumentPath}?auth={_firebaseSettings.UserToken}";
        }
    }
}
