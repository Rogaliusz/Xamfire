using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts.Builders;
using Xamfire.Contexts.Configurations;
using Xamfire.Json.Serializer.ContractResolver;
using Xamfire.Json.Serializer.Document;
using Xamfire.Settings;
using Xamfire.Tests.Integration.Mock;

namespace Xamfire.Tests.Integration
{
    public abstract class IntegrationTestBase<TModel>
    {
        protected static IFirebaseSettings FirebaseSettingsMock { get; private set; } = new FirebaseSettingsMock();

        protected IDocumentModelBuilder<TModel> GetBuilder()
        {
            var modelConfiguration = GetModelConfiguration();
            var contactResolver = new DocumentContractResolver<TModel>(modelConfiguration);
            var jsonSerializer = new JsonDocumentSerializer();
            var documentBuilder = new DocumentModelBuilder<TModel>(jsonSerializer, FirebaseSettingsMock);

            return documentBuilder;
        }

        protected abstract IModelConfiguration<TModel> GetModelConfiguration();
    }
}
