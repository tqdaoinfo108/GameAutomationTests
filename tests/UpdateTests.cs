using AltTester.AltTesterUnitySDK.Driver;
using alttrashcat_tests_csharp.pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAlttrashCSharp.support_utils;
using static TestAlttrashCSharp.support_utils.Constant;
using By = OpenQA.Selenium.By;

namespace TestAlttrashCSharp.tests
{
    public class UpdateTests
    {

        private readonly string updateBtnXpath = "//android.widget.Button[@resource-id=\"com.android.vending:id/0_resource_name_obfuscated\" and @text=\"Update\"]";
        private readonly string closeBtnXpath = "//android.widget.ImageView[@content-desc=\"Dismiss update dialog\"]";

        /// <summary>
        ///       Chờ nút Update xuất hiện, ngôn ngữ máy là: En
        /// </summary>
        /// <param name="timeOut"> Đơn vị giây</param>
        /// <param name="retryCount"> Số lần gọi lại</param>
        /// <returns>Click thành công trả về true, timeout > false</returns>
        private bool waitClickUpdateAndCloseButton(dynamic appiumDriver, int timeOut, int retryCount, string xPath)
        {
            int i = 0;
            while (i < retryCount)
            {
                try
                {
                    var UpdateButtonI = appiumDriver.FindElement(By.XPath(xPath));
                    UpdateButtonI.Click();
                    // chờ 1 phút cho update xong
                    Thread.Sleep(1 * 1000);
                    return true;
                }
                catch (Exception e)
                {
                    // Xử lý lỗi và tăng biến đếm retry
                    i++;
                    Thread.Sleep(timeOut * 1000);
                }
            }
            return false;
        }

        /// <summary>
        ///     Immediately 
        ///     Test tự setup appium & alt, không cần kế thừa BaseTest
        /// </summary>
        [Test]
        public void UpdateSuccessImmediately()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, false).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Chờ thông báo cập nhật của hệ thống, 10 lần, mỗi lần 3s
            bool isClickedUpdateBtn = waitClickUpdateAndCloseButton(driverAppium, 3, 10, updateBtnXpath); 
            // Không click được thì fail
            if(!isClickedUpdateBtn) Assert.Fail();

            // Chờ 60s để cập nhật và vào lại game, tuỳ thuộc vào mạng,cấu hình máy hoặc có thể getActivity hiện tại để check vào game được chưa
            Thread.Sleep(60 * 1000);

            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new ();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new (altDriver);

            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();

            // Clicks on setting để so sánh số version ( ver mới > ver trước đó) | 240321330 là số version trước đó, có thể cấu hình ở đâu đó trước khi chạy test
            mainMenuPage.SettingIcon.Click();
            var textVersion = mainMenuPage.TextVersion.GetText();
            textVersion = textVersion.Split('(')[1].Split(')')[0];
            Assert.True(int.Parse(textVersion) > 240321330);
        }

        /// <summary>
        ///     Tắt update (immediately, Flexiable) -> boi vi dung chung xpath nen chi viet 1 Test 
        ///     nhung 2 case
        /// </summary>
        [Test]
        public void CloseUpdateTest()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, false).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Chờ thông báo cập nhật của hệ thống, 10 lần, mỗi lần 3s
            bool isClickedUpdateBtn = waitClickUpdateAndCloseButton(driverAppium, 3, 10, closeBtnXpath);
            // Không click được thì fail
            if (!isClickedUpdateBtn) Assert.Fail();

            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();
                // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);

            // Clicks "Yes" để thoát khỏi màn chơi 
            mainMenuPage.NoGiveUpButton.Click();
            Thread.Sleep(5 * 1000);
            // Nếu không quăng exeption > pass
            Assert.True(true);
        }

        [Test]
        public void UpdateSuccessFlexible()
        {
            // Kết nối Appium
            var driverAppium = new SetupUtils(PlatformInfo.Android, false).GetAppiumDriver() as AndroidDriver<AndroidElement>;

            // Chờ thông báo cập nhật của hệ thống, 10 lần, mỗi lần 3s
            bool isClickedUpdateBtn = waitClickUpdateAndCloseButton(driverAppium, 3, 10, updateBtnXpath);
            // Không click được thì fail
            if (!isClickedUpdateBtn) Assert.Fail();

           
            // Kết nối Alt để thao tác trên game
            AltDriver altDriver = new();

            // Khởi tạo các nút trong alt để thao tác
            MainMenuPage mainMenuPage = new(altDriver);
            // Chờ 60s để cập nhật và vào lại game, tuỳ thuộc vào mạng,cấu hình máy hoặc có thể getActivity hiện tại để check vào game được chưa
            Thread.Sleep(60 * 1000);

            // Clicks "No" để thoát khỏi màn chơi 
            mainMenuPage.NoGiveUpButton.Click();

            // Đợi download 100% nút restart hiển thị -> sau đó click nút restart
            mainMenuPage.ReStartButton.Click();
            // Dừng phiên làm việc trước
            altDriver.Stop();

            // dừng 10s
            Thread.Sleep(10 * 1000);
            // Kết nối lại AltDriver
            altDriver = new();
            mainMenuPage = new(altDriver);

            // Clicks on setting để so sánh số version ( ver mới > ver trước đó) | 240321330 là số version trước đó, có thể cấu hình ở đâu đó trước khi chạy test
            mainMenuPage.PauseIcon.Click();
            mainMenuPage.YesGiveUpButton.Click();
            mainMenuPage.SettingIcon.Click();
            var textVersion = mainMenuPage.TextVersion.GetText();
            textVersion = textVersion.Split('(')[1].Split(')')[0];
            Assert.True(int.Parse(textVersion) > 240321330);
        }
    }
}
