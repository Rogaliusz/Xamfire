using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Settings;

namespace Xamfire.Tests.Integration.Mock
{
    public class FirebaseSettingsMock : IFirebaseSettings
    {
        public long ProjectNumber => 177777;

        public string Url => "http://sample-base.net.pl.eu/";

        public string MobileSdkAppId => "sample_sdk";

        public string StorageBucket => "sample_bucket";

        public string ApiKey => "sample_key";

        public string ClientId => "sample_id";

        public int ClientType => 11;

        public string UserToken { get; set; } = "token";
            
        public string UserRefreshToken { get; set; } = "refresh_token";

        public void Load()
        {
        }
    }
}
