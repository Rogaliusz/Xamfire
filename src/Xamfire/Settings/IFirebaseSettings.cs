using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Settings
{
    public interface IFirebaseSettings
    {
        long ProjectNumber { get; }
        string Url { get; }
        string MobileSdkAppId { get; }
        string StorageBucket { get; }
        string ApiKey { get; }
        string ClientId { get; }
        int ClientType { get; }

        void Load();
    }
}
