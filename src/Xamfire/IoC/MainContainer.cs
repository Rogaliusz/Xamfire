using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamfire.Contexts.Auth;
using Xamfire.Json.Serializer.ContractResolver;
using Xamfire.Json.Serializer.Document;
using Xamfire.Network.Service;

namespace Xamfire.IoC
{
    internal static class MainContainer
    {
        private static TinyIoCContainer Container => TinyIoC.TinyIoCContainer.Current;

        public static void RegisterServices()
        {
            RegisterSingleton<IJsonDocumentSerializer, JsonDocumentSerializer>();
            RegisterSingleton<IAuthenticationContext, AuthenticationContext>();
            RegisterSingleton<INetworkService, NetworkService>();
            RegisterSingleton<XamfireContractResolver, CamelCaseContractResolver>();
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
