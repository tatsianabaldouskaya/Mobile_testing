using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Mobile_testing    
{
    [TestFixture]
    public class Tests
    {
        private string path = @"C:/Users/Tatsiana_Baldouskaya/source/repos/Mobile_testing/test.apk";
        private IApp app;
        private AppiumDriver<AndroidElement> appiumDriver;

        [SetUp]
        public void SetUp()
        {
           // app = AppInstaller.StartApp(Platform.Android, path);
        }
        
        [Test]
        public void XamarinTest()
        {
            app = AppInstaller.StartApp(Xamarin.UITest.Platform.Android, path);
            app.Repl();
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("menu_search"));
            app.DismissKeyboard();
            app.EnterText(c => c.Id("menu_search"), "samsung");
            app.DismissKeyboard();
            app.ScrollDownTo(c => c.Marked("Samsung Gear S3 frontier [SM-R760]"));
        }

        [Test]
        public void AppiumTest()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Oreo");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.App, path);
            options.AddAdditionalCapability("chromedriverExecutable", @"D:\webdriver\chromedriver.exe");
            
            
            appiumDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
            Assert.NotNull(appiumDriver.Context);
        }
    }
}
