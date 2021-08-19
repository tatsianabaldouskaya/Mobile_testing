using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Linq;

namespace Mobile_testing    
{
    [TestFixture]
    public class Tests
    {
        static readonly Func<AppQuery, AppQuery> iphone12 = c => c.Marked("Смартфон Apple iPhone 12 mini 64GB (синий)");
        private string newApp = @"C:/Users/Tatsiana_Baldouskaya/source/repos/Mobile_testing/onliner.apk";
        private string oldApp = @"C:/Users/Tatsiana_Baldouskaya/source/repos/Mobile_testing/test.apk";
        private IApp app;
        private AppiumDriver<AndroidElement> appiumDriver;

        [SetUp]
        public void SetUp()
        {
           // app = AppInstaller.StartApp(Platform.Android, path);
        }
        
        [Test]
        public void UserInstructionDisplayingTest()
        {
            app = AppInstaller.StartApp(Xamarin.UITest.Platform.Android, newApp);
           // app.Repl();
            Assert.IsTrue(app.Query(x => x.Text("Добро пожаловать!")).Any());
        }


        [Test]
        public void PriceTest()
        {
           // AppResult[] result = app.Query(iPhone12);
            app = AppInstaller.StartApp(Xamarin.UITest.Platform.Android, newApp);
          //app.Repl();
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("searchPlate"));
            app.Repl();
            app.DismissKeyboard();
            app.EnterText("iphone 12");
            app.ScrollDownTo(c => c.Marked("Смартфон Apple iPhone 12 128GB (зеленый)"));
            app.Tap(c => c.Marked("Смартфон Apple iPhone 12 128GB (зеленый)"));
            app.Tap(c => c.Marked("Navigate up"));
            app.ScrollDownTo(c => c.Id("offerPriceRangeView"));
            Assert.IsTrue(app.Query(x => x.Id("offerPriceRangeView")).Any());
            var price = (app.Query(c => c.Id("offerPriceRangeView"))[0].Text);
            var price2 = price.Substring(0, 7);
          
            //var price = app.Query(c => c.Id("offerPriceRangeView").Invoke("getText")).ToList();
            Assert.AreEqual("2400,00", price2, "Incorrect price value");


        }

        [Test]
        public void AppiumTest()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "8.0");
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Oreo2");
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "by.onliner.catalog");
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "by.onliner.catalog.splash.SplashActivity");
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, "by.onliner.catalog.activity.MainActivity");
            options.AddAdditionalCapability(MobileCapabilityType.App, newApp);
            options.AddAdditionalCapability(MobileCapabilityType.FullReset, false);


           appiumDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
            appiumDriver.FindElement(By.Id("nextView")).Click();
            appiumDriver.FindElement(By.Id("nextView")).Click();
            appiumDriver.FindElement(By.Id("nextView")).Click();
            appiumDriver.FindElement(By.Id("nextView")).Click();
            appiumDriver.FindElement(By.Id("nextView")).Click();
            Assert.NotNull(appiumDriver.Context);
        }

        [Test]
        public void CloudTest()
        {
            AppInstaller.OnCreate();
        }
    }
}
