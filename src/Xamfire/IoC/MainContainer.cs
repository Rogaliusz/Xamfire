using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamfire.Contexts.Auth;
using Xamfire.Document.Builders;
using Xamfire.Document.Configurations;
using Xamfire.Document.ContractResolver;
using Xamfire.Document.Serializer;
using Xamfire.Network.Service;

namespace Xamfire.IoC
{
    internal static class MainContainer
    {
        private static TinyIoCContainer Container => TinyIoC.TinyIoCContainer.Current;

        public static void RegisterServices()
        {
            RegisterSingleton<IAuthenticationContext, AuthenticationContext>();
            RegisterSingleton<INetworkService, NetworkService>();

            Container.Register<IDocumentSerializer, DocumentSerializer>().AsMultiInstance();

            Container.Register(typeof(IDocumentModelBuilder<>), typeof(DocumentModelBuilder<>)).AsMultiInstance();
            Container.Register(typeof(IDocumentConfiguration<>), typeof(DocumentConfiguration<>)).AsMultiInstance();
            Container.Register(typeof(XamfireContractResolver), typeof(DocumentContractResolver<>)).AsMultiInstance();
        }

        internal static TInstance ResolveInstance<TInstance>(NamedParameterOverloads @params)
            where TInstance : class
        {
            return Container.Resolve<TInstance>(@params);
        }

        internal static TInstance ResolveInstance<TInstance>()
            where TInstance : class
        {
            return Container.Resolve<TInstance>();
        }

        internal static void ReplaceService<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            Container.Register<TAbstraction, TImplementation>();
        }

        internal static void RegisterSingleton<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            Container.Register<TAbstraction, TImplementation>().AsSingleton();
        }

        internal static void RegisterInstanceAsSingleton<TInstance>(TInstance instance)
            where TInstance : class
        {
            Container.Register(instance);
        }
    }
}
