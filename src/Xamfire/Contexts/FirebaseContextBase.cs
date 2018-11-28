using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Contexts.Configurations;
using Xamfire.Json.Network;
using Xamfire.Json.Serializer;
using Xamfire.Settings;

namespace Xamfire.Contexts
{
    public abstract class FirebaseContextBase<TModel> 
    {
        private readonly INetworkService _networkService;
        private readonly IFirebaseSettings _firebaseSettings;

        public abstract void Configure(IModelConfiguration<TModel> modelConfiguration);
    }
}
