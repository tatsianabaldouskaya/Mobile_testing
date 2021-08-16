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
          // app.Repl();
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("searchPlate"));
            app.DismissKeyboard();
            app.EnterText("iphone 12");
            app.DismissKeyboard();
            app.ScrollDownTo(c => c.Marked("Смартфон Apple iPhone 12 128GB (зеленый)"));
            app.Tap(c => c.Marked("Смартфон Apple iPhone 12 128GB (зеленый)"));
            app.ScrollDownTo(c => c.Id("offerPriceRangeView"));
            Assert.IsTrue(app.Query(x => x.Id("offerPriceRangeView")).Any());
          //  string[] price = app.Query(c => c.Id("offerPriceRangeView").Invoke("getText")).Cast<String>().ToArray();
          //  Assert.AreEqual("2400,00 р.", price, "Incorrect price value");
            
         
        }

        [Test]
        public void AppiumTest()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Oreo");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.App, newApp);
            options.AddAdditionalCapability("chromedriverExecutable", @"D:\webdriver\chromedriver.exe");


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
