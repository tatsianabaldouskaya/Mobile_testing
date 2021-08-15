using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.UITest;

namespace Mobile_testing
{
    public static class AppInstaller
    {
        public static IApp StartApp(Platform platform, string pathToApp)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.
                    Android.
                    ApkFile(pathToApp).
                    StartApp();
            }
            else
            {
                return ConfigureApp.
                    iOS.
                    StartApp();
            }
        }

        public static void OnCreate()
        {
            AppCenter.Start("1f6e1663-642e-4d0f-8e39-aefde8a0817b",
                   typeof(Analytics), typeof(Crashes));
        }
    }
}
