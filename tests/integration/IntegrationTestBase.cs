using Xamfire.Document.Builders;
using Xamfire.Document.Configurations;
using Xamfire.Document.ContractResolver;
using Xamfire.Document.Serializer;
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
            var jsonSerializer = new DocumentSerializer();
            var documentBuilder = new DocumentModelBuilder<TModel>(jsonSerializer, FirebaseSettingsMock);

            return documentBuilder;
        }

        protected abstract IDocumentConfiguration<TModel> GetModelConfiguration();
    }
}
