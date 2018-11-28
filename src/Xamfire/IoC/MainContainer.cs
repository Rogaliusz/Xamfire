using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;

namespace Xamfire.IoC
{
    internal static class MainContainer
    {
        private static TinyIoCContainer Container => TinyIoC.TinyIoCContainer.Current;

        public static void RegisterServices()
        {

        }

        public static TInstance ResolveInstance<TInstance>()
            where TInstance : class
        {
            return Container.Resolve<TInstance>();
        }

        public static void ReplaceService<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            Container.Register<TAbstraction, TImplementation>();
        }
    }
}
