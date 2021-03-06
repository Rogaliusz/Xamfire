﻿using System;
using System.Linq;
using System.Reflection;

using Android.Content;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Settings;
using Xamfire.Settings;
using Xamfire.Extensions;
using System.Text.RegularExpressions;
using Android.Preferences;

namespace Xamfire.Android.Settings
{
    public class FirebaseSettings : IFirebaseSettings
    {
        private readonly Context _context;
        private readonly ISharedPreferences _sharedPreferences;

        public long ProjectNumber { get; private set; }
        public string Url { get; private set; }
        public string MobileSdkAppId { get; private set; }
        public string StorageBucket { get; private set; }
        public string ApiKey { get; private set; }
        public string ClientId { get; private set; }
        public int ClientType { get; private set; }

        public string UserToken
        {
            get => _sharedPreferences.GetString(nameof(UserToken), "");
            set
            {
                var editor = _sharedPreferences.Edit();
                editor.PutString(nameof(UserToken), value);
                editor.Commit();
            }
        }

        public string UserRefreshToken
        {
            get => _sharedPreferences.GetString(nameof(UserRefreshToken), "");
            set
            {
                var editor = _sharedPreferences.Edit();
                editor.PutString(nameof(UserRefreshToken), value);
                editor.Commit();
            }
        }

        public FirebaseSettings(Context context)
        {
            _context = context;
            _sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(context);
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
            StorageBucket   = GetStringFromResource(Resources.STORAGE_BUCKET, stringResourceFields);
            ApiKey          = GetStringFromResource(Resources.API_KEY, stringResourceFields);
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

            public const string RESOURCE_STRING_NAMESPACE_PATTERN = @"Resource[\.*+]String"; // Pattern using for samp  le like Resource+String or Resource.String
        }
    }
}