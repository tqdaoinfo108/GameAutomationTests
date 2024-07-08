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
    public class CompareSDK
    {
        [Test]
        public void CompareSDKIronsource()
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

            Thread.Sleep(10000);

            _ = driverAppium.PageSource;
            _ = driverAppium.PageSource;
            string sdkVersionValue = driverAppium.FindElement(By.XPath(Path.SdkVersionPath)).Text;
            Assert.AreEqual("7.8.0", sdkVersionValue);
        }
       
    }

}
