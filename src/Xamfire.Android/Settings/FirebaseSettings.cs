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
using Xamfire.Extensions;
using System.Text.RegularExpressions;

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
            var contextAssembly = _context.GetType().Assembly;
            var regexPattern = new Regex(Resources.RESOURCE_STRING_NAMESPACE_PATTERN);

            var stringResourceFields = contextAssembly
                .GetTypes()
                .FirstOrDefault(x => !x.FullName.IsEmpty() && regexPattern.IsMatch(x.FullName))
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            Url             = GetStringFromResource(Resources.URL, stringResourceFields);
            ApiKey          = GetStringFromResource(Resources.API_KEY, stringResourceFields);
            StorageBucket   = GetStringFromResource(Resources.STORAGE_BUCKET, stringResourceFields);
            ClientId        = GetStringFromResource(Resources.CLIENT_ID, stringResourceFields);
        }

        private string GetStringFromResource(string resourceName, FieldInfo[] stringResourceFields)
        {
            var resource = stringResourceFields.SingleOrDefault(x => x.Name == resourceName)?
                .GetValue(null)?
                .ToString();

            if (resource == null)
                throw new InvalidConfigException(ExceptionMessages.INVALID_CONFIG_FILE);

            return _context.GetString(Int32.Parse(resource));
        }


        private static class Resources
        {
            public const string API_KEY = "google_api_key";
            public const string URL = "firebase_database_url";
            public const string CLIENT_ID = "default_web_client_id";
            public const string STORAGE_BUCKET = "google_storage_bucket";

            public const string RESOURCE_STRING_NAMESPACE_PATTERN = @"Resource[\.*+]String"; // Pattern using for sample like Resource+String or Resource.String
        }

    }


}