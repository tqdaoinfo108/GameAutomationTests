using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestAlttrashCSharp.support_utils.Constant;
using TestAlttrashCSharp.Model;
using TestAlttrashCSharp.support_utils;

namespace TestAlttrashCSharp.tests
{
    public class Kidoz
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
            string loadAdsPath = "//   android.widget.TextView[@text=\"Load ad\"]";
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
                    if (title != null && title.Equals("fyber", StringComparison.InvariantCultureIgnoreCase))
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

            bool isGetAds = TryGetAdsAndReturn(driverAppium, indexTab: 0); //indexTab:0 la tab RV
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = returnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "fyber");
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
            string loadAdsPath = "//   android.widget.TextView[@text=\"Load ad\"]";
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
                    if (title != null && title.Equals("fyber", StringComparison.InvariantCultureIgnoreCase))
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

            bool isGetAds = TryGetAdsAndReturn(driverAppium, indexTab: 1);
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = returnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "fyber");
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
            string loadAdsPath = "//   android.widget.TextView[@text=\"Load ad\"]";
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
                    if (title != null && title.Equals("fyber", StringComparison.InvariantCultureIgnoreCase))
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

            bool isGetAds = TryGetAdsAndReturn(driverAppium, indexTab: 2);
            Assert.IsTrue(isGetAds);

            Thread.Sleep(4000);
            List<string> list = driverAppium.Manage().Logs.GetLog("logcat").Select(s => s.Message).ToList();
            var ad = returnAdPlatformObject(list);
            Assert.NotNull(ad);
            Assert.AreEqual(ad.ad_source, "fyber");
            Assert.True(ad.value < 1);
        }
        private bool TryGetAdsAndReturn(AndroidDriver<AndroidElement> driverAppium, int indexTab = 0, int maxRetry = 5)
        {
            bool isResult = false;
            List<String> listTabs = new() { Path.TabRV, Path.TabFS, Path.TabBN };

            string paths = listTabs[0];
            foreach (string path in new List<string>() { paths })
            {
                if (isResult) break;
                var tab = SetupUtils.TryFindElement(driverAppium, path);
                if (tab == null) continue;
                SetupUtils.ClickCustom(driverAppium, path);

                for (var i = 0; i < maxRetry; i++)
                {
                    var btnShowAds = SetupUtils.TryFindElement(driverAppium, Path.ShowAdsBtnPath);
                    if (btnShowAds != null)
                    {
                        btnShowAds.Click();
                        isResult = true;
                        break;
                    }
                    else
                    {
                        var btnLoadAd = SetupUtils.TryFindElement(driverAppium, Path.FailAdsBtnPath);
                        if (btnLoadAd != null)
                            btnLoadAd.Click();
                        Thread.Sleep(8000);
                    }
                }
            }

            return isResult;
        }

        // Helper
        private bool isMatchAdimpression(List<string> logs, string ad_source, double valueMax)
        {
            bool isResult = false;
            var dateNow = DateTime.Now; // utc theo hệ thống
            var listFilter = logs.AsEnumerable().Where(x => x.Contains(Path.cSplit));
            if (listFilter.Any())
            {
                // Tìm đến phần tử cuối cùng
                string item = listFilter.LastOrDefault().ToLower();
                string[] itemArr = item.Split(Path.cSplit);
                if (itemArr.Length == 2) // cấu trúc thì có 2 phần, index = 1 là json
                {
                    AdPlatformObject adPlatformObject = JsonHelpers.CreateFromJsonString<AdPlatformObject>(itemArr[1]);
                    return adPlatformObject != null && adPlatformObject.ad_source == ad_source && adPlatformObject.value < valueMax;
                }
            }

            return isResult;
        }
        private AdPlatformObject returnAdPlatformObject(List<string> logs)
        {
            bool isResult = false;
            var dateNow = DateTime.Now; // utc theo hệ thống
            var listFilter = logs.AsEnumerable().Where(x => x.Contains(Path.cSplit));
            if (listFilter.Any())
            {
                // Tìm đến phần tử cuối cùng
                string item = listFilter.LastOrDefault().ToLower();
                string[] itemArr = item.Split(Path.cSplit);
                if (itemArr.Length == 2) // cấu trúc thì có 2 phần, index = 1 là json
                {
                    AdPlatformObject adPlatformObject = JsonHelpers.CreateFromJsonString<AdPlatformObject>(itemArr[1]);
                    return adPlatformObject;
                }
            }

            return null;
        }
    }
}
