using Android.Content;
using System;
using Xamfire.Android.Settings;
using Xamfire.Settings;
using XamfireShared = Xamfire.Xamfire;

namespace Xamfire.Android
{
    public static class Xamfire
    {
        public static void Initialization(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            XamfireShared.RegisterInstanceAsSingleton(context);
            XamfireShared.RegisterFirebaseSettings<FirebaseSettings>();

            XamfireShared.Initalization();
        }
    }
}
