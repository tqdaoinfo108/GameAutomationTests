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
    public class CompareSDKAdSource
    {

        public class AdSource
        {
            public string AdsName { get; set; }
            public string SdkVersion { get; set; }
            public string AdapterVersion { get; set; }

            public AdSource(string AdsName, string SdkVersion, string AdapterVersion) 
            {
                this.AdsName = AdsName;
                this.AdapterVersion = AdapterVersion;
                this.SdkVersion = SdkVersion;
            }
            public static List<AdSource> GetListAdSource()
            {
                var list = new List<AdSource>
                {
                    new AdSource("adManager", "22.6.0", "4.43.41"),
                    new AdSource("applovin", "12.1.0", "4.3.41"),
                    new AdSource("aps", "aps-android-9.8.10", "4.3.11"),
                    new AdSource("bidmachine", "2.4.2", "4.3.5"),
                    new AdSource("fyber", "8.2.5", "4.3.29"),
                    new AdSource("google", "22.6.0", "4.3.41"),
                    new AdSource("hyprMx", "6.2.3", "4.3.6"),
                    new AdSource("Inmobi", "10.6.3", "4.3.22"),
                    new AdSource("ironsource", "7.7.0", "7.7.0"),
                    new AdSource("liftoff Monetize", "7.1.0", "4.3.23"),
                    new AdSource("meta", "6.16.0", "4.3.45"),
                    new AdSource("Mintegral", "MAL_16.6.31", "4.3.24"),
                    new AdSource("Mytarget", "5.20.0", "4.1.19"),
                    new AdSource("pangle", "5.7.0.3", "4.3.25"),
                    new AdSource("smaato", "22.0.2", "4.3.9"),
                    new AdSource("superawesome", "9.3.2", "4.1.8"),
                    new AdSource("unityads", "4.9.2", "4.3.34"),
                    new AdSource("Bigo ads", "4.5.1", "4.5.1.1"),
                    new AdSource("kidoz", "9.0.2", "1.2.0"),
                    new AdSource("maticoo", "1.5.2", "1.5.2"),
                    new AdSource("moloco", "1.7.0", "1.7.0.0"),
                    new AdSource("Ogury", "5.6.2", "5.6.2.0"),
                    new AdSource("Yandex", "6.4.0", "6.4.0.0")
                };
                return list;
            }
        }

        [Test]
        public void CompareSDKandAdapter()
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
            SetupUtils.ClickCustom(driverAppium, sourcePath);
            Thread.Sleep(2000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;
            // Scroll to end listview
            var size = driverAppium.Manage().Window.Size;
            var startX = size.Width / 2;

            var endX = size.Height * 0.7;
            var endY = size.Height * 0.3;

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;

            Dictionary<string, (string, string)> listDictionary = new Dictionary<string, (string, string)>();
            for (int i = 1; i < 12; i++)
            {
                for(int j = 1; j < 6; j++)
                {
                    var title = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 1))?.Text;
                    var sdkVersion = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 3))?.Text;
                    var adapterVersion = SetupUtils.TryFindElement(driverAppium, string.Format(Path.AdSourceTitle, j, 4))?.Text;
                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(sdkVersion) || string.IsNullOrEmpty(adapterVersion)) continue;

                    if (listDictionary.TryGetValue(title.ToLower(), out var list) && !string.IsNullOrEmpty(list.Item1))
                    {
                        listDictionary[title.ToLower()] = (sdkVersion, adapterVersion);
                    }
                    else
                    {
                        listDictionary.Add(title.ToLower(), (sdkVersion, adapterVersion));
                    }
                }
                SetupUtils.Swipe(driverAppium, startX, endX, startX, endY);
                _ = driverAppium.PageSource;
                _ = driverAppium.PageSource;
            }
            foreach (var item in AdSource.GetListAdSource())
            {
                Assert.AreEqual(listDictionary[item.AdsName.ToLower()].Item1, $"sdk version {item.SdkVersion}");
                Assert.AreEqual(listDictionary[item.AdsName.ToLower()].Item2, $"adapter {item.AdapterVersion}");
            }
        }
    }
}
