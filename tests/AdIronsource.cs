using OpenQA.Selenium.Appium.Android;
using System.Linq;
using static TestAlttrashCSharp.support_utils.Constant;
using TestAlttrashCSharp.support_utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using By = OpenQA.Selenium.By;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using TestAlttrashCSharp.Model;

namespace TestAlttrashCSharp.tests
{
    public class AdIronsource
    {

        [Test]
        public void RV()
        {
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Kết nối Appium
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();
            Thread.Sleep(10000);
            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            var position = mainMenuPage.TestSuiteButton.getScreenPosition();
            altDriver.Click(new AltVector2(position.x + 5, position.y + 5), count: 4, interval: 0.5f, wait: false);
            altDriver.Stop();

            Thread.Sleep(5000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;

            string sourcePath = "//android.view.View[@content-desc=\"Ad sources\"]";
            string loadAdsPath = "//android.widget.TextView[@text=\"Load ad\"]";
            SetupUtils.ClickCustom(driverAppium, sourcePath);
            Thread.Sleep(2000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;
            var size = driverAppium.Manage().Window.Size;
            var startX = size.Width / 2;

            var endX = size.Height * 0.8;
            var endY = size.Height * 0.2;

            Dictionary<string, (string, string)> listDictionary = new Dictionary<string, (string, string)>();
            bool isFound = false;
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    var itemAd = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 1));
                    var title = itemAd?.Text;
                    if (title != null && title.Equals("ironsource", StringComparison.InvariantCultureIgnoreCase))
                    {
                        itemAd.Click();
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;

                SetupUtils.Swipe(driverAppium, startX, endX, startX, endY);
                _ = driverAppium.PageSource;
                _ = driverAppium.PageSource;
            }

            SetupUtils.ClickCustom(driverAppium, loadAdsPath);
            Thread.Sleep(7000);

            bool isGetAds = SetupUtils.TryGetAdsAndReturn(driverAppium, indexTab: 0); //indexTab:0 la tab RV
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = SetupUtils.ReturnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "ironsource");
            Assert.True(ad.value < 1);
        }
        [Test]
        public void FS()
        {
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Kết nối Appium
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();
            Thread.Sleep(10000);
            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            var position = mainMenuPage.TestSuiteButton.getScreenPosition();
            altDriver.Click(new AltVector2(position.x + 5, position.y + 5), count: 4, interval: 0.5f, wait: false);
            altDriver.Stop();

            Thread.Sleep(5000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;

            string sourcePath = "//android.view.View[@content-desc=\"Ad sources\"]";
            string loadAdsPath = "//android.widget.TextView[@text=\"Load ad\"]";
            SetupUtils.ClickCustom(driverAppium, sourcePath);
            Thread.Sleep(2000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;
            var size = driverAppium.Manage().Window.Size;
            var startX = size.Width / 2;

            var endX = size.Height * 0.8;
            var endY = size.Height * 0.2;

            Dictionary<string, (string, string)> listDictionary = new Dictionary<string, (string, string)>();
            bool isFound = false;
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    var itemAd = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 1));
                    var title = itemAd?.Text;
                    if (title != null && title.Equals("ironsource", StringComparison.InvariantCultureIgnoreCase))
                    {
                        itemAd.Click();
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;

                SetupUtils.Swipe(driverAppium, startX, endX, startX, endY);
                _ = driverAppium.PageSource;
                _ = driverAppium.PageSource;
            }
            bool isGetAds = SetupUtils.TryGetAdsAndReturn(driverAppium, indexTab: 1);
            SetupUtils.ClickCustom(driverAppium, loadAdsPath);
            Thread.Sleep(7000);

           // bool isGetAds = SetupUtils.TryGetAdsAndReturn(driverAppium, indexTab: 1);
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = SetupUtils.ReturnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "ironsource");
            Assert.True(ad.value < 1);
        }

        [Test]
        public void BN()
        {
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Kết nối Appium
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();
            Thread.Sleep(10000);
            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            var position = mainMenuPage.TestSuiteButton.getScreenPosition();
            altDriver.Click(new AltVector2(position.x + 5, position.y + 5), count: 4, interval: 0.5f, wait: false);
            altDriver.Stop();

            Thread.Sleep(5000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;

            string sourcePath = "//android.view.View[@content-desc=\"Ad sources\"]";
            string loadAdsPath = "//android.widget.TextView[@text=\"Load ad\"]";
            SetupUtils.ClickCustom(driverAppium, sourcePath);
            Thread.Sleep(2000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;
            var size = driverAppium.Manage().Window.Size;
            var startX = size.Width / 2;

            var endX = size.Height * 0.8;
            var endY = size.Height * 0.2;

            Dictionary<string, (string, string)> listDictionary = new Dictionary<string, (string, string)>();
            bool isFound = false;
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    var itemAd = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 1));
                    var title = itemAd?.Text;
                    if (title != null && title.Equals("ironsource", StringComparison.InvariantCultureIgnoreCase))
                    {
                        itemAd.Click();
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;

                SetupUtils.Swipe(driverAppium, startX, endX, startX, endY);
                _ = driverAppium.PageSource;
                _ = driverAppium.PageSource;
            }
            bool isGetAds = SetupUtils.TryGetAdsAndReturn(driverAppium, indexTab: 2);
            SetupUtils.ClickCustom(driverAppium, loadAdsPath);
            Thread.Sleep(7000);

            //bool isGetAds = SetupUtils.TryGetAdsAndReturn(driverAppium, indexTab: 2);
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = SetupUtils.ReturnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "ironsource");
            Assert.True(ad.value < 1);
        }
      
    }
}
