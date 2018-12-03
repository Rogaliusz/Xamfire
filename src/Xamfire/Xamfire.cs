using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamfire.Contexts.Auth;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Settings;
using Xamfire.IoC;
using Xamfire.Settings;

namespace Xamfire.Shared
{
    public class Xamfire
    {
        public static IAuthenticationContext AuthenticationContext
        {
            get
            {
                try
                {
                    return MainContainer.ResolveInstance<IAuthenticationContext>();
                }
                catch (TinyIoCResolutionException)
                {
                    throw new InvalidConfigException(ExceptionMessages.XAMFIRE_WAS_NOT_INITALIZED);
                }
            }
        }


        static Xamfire()
        {
            MainContainer.RegisterServices();
        }

        public static void ReplaceService<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class, TInterface
                => MainContainer.ReplaceService<TInterface, TImplementation>();

        public static void RegisterInstanceAsSingleton<TInstance>(TInstance instance)
            where TInstance : class
                => MainContainer.RegisterInstanceAsSingleton(instance);

        public static void RegisterFirebaseSettings<TFirebaseSettings>()
            where TFirebaseSettings : class, IFirebaseSettings
                => MainContainer.RegisterSingleton<IFirebaseSettings, TFirebaseSettings>();

        public static void Initalization()
        {
            var settings = MainContainer.ResolveInstance<IFirebaseSettings>();

            if (settings == null)
                throw new InvalidConfigException(ExceptionMessages.MISSING_IMPLEMENTATION);

            settings.Load();
        }

        private static Exception InvalidConfigException()
        {
            throw new NotImplementedException();
        }
    }
}
