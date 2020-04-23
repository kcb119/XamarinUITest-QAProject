using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestXamarin
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .InstalledApp("XamarinApp.Android")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}