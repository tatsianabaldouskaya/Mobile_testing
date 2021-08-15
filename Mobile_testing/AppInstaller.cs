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
    }
}
