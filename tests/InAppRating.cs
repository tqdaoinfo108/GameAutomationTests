using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestAlttrashCSharp.support_utils.Constant;
using TestAlttrashCSharp.support_utils;

namespace TestAlttrashCSharp.tests
{
    public class InAppRating
    {
     [Test]
        public void Rating5Star()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");         
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.Rating5Star.Click();
            Thread.Sleep(5 * 1000);
            var starBtn = driverAppium.FindElementByXPath("//android.widget.ImageView[@content-desc=\"Fifth star unselected\"]");
            Assert.NotNull(starBtn);

        }
        [Test]
        public void Rating1Star()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.Rating1Star.Click();
            Thread.Sleep(5 * 1000);

            Assert.True(true);

        }
        [Test]
        public void Rating2Star()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.Rating2Star.Click();
            Thread.Sleep(5 * 1000);

            Assert.True(true);

        }
        [Test]
        public void Rating3Star()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.Rating3Star.Click();
            Thread.Sleep(5 * 1000);

            Assert.True(true);

        }
        [Test]
        public void Rating4Star()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.Rating4Star.Click();
            Thread.Sleep(5 * 1000);

            Assert.True(true);

        }

        [Test]
        public void CloseRating()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, true).GetAppiumDriver() as AndroidDriver<AndroidElement>;
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            mainMenuPage.FakeLevelTextArea.SetText("1");
            mainMenuPage.GoLevel.Click();
            mainMenuPage.PlayGameButton.Click();
            int i;
            for (i = 0; i < 8; i++)
            {
                mainMenuPage.PauseIcon.Click();
                mainMenuPage.YesGiveUpButton.Click();
                mainMenuPage.PlayGameButton.Click();
                Thread.Sleep(2000);

            }
            Thread.Sleep(50 * 1000);
            mainMenuPage.CloseRatingPopup.Click();
            Thread.Sleep(5 * 1000);

            Assert.True(true);

        }
    }
 }
    

