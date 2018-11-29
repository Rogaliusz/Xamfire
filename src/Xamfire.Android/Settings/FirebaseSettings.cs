using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Settings;
using Xamfire.Json.Serializer.Document;
using Xamfire.Settings;

namespace Xamfire.Android.Settings
{
    public class FirebaseSettings : IFirebaseSettings
    {
        private readonly Context _context;

        public long ProjectNumber { get; private set; }
        public string Url { get; private set; }
        public string MobileSdkAppId { get; private set; }
        public string StorageBucket { get; private set; }
        public string ApiKey { get; private set; }
        public string ClientId { get; private set; }
        public int ClientType { get; private set; }

        public FirebaseSettings (Context context)
        {
            _context = context;
        }

        public void Load()
        {
            var settings = typeof(Resource.String).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            throw new InvalidConfigException(ExceptionMessages.INVALID_CONFIG_FILE);
        }
    }
}