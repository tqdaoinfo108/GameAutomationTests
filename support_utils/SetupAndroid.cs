using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlttrashCSharp.support_utils
{
    public class SetupAndroid
    {
        public static AndroidDriver<AndroidElement> Setup(bool isReset = false)
        {
            AndroidDriver<AndroidElement> appiumDriver;
            var serverUri = new Uri("http://127.0.0.1:4723/wd/hub");

            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "android");
            //options.AddAdditionalCapability("appium:automationName", "uiautomator2");
            options.AddAdditionalCapability("appium:ensureWebviewsHavePages", true);
            options.AddAdditionalCapability("appium:nativeWebScreenshot", true);
            options.AddAdditionalCapability("appium:newCommandTimeout", 3600);
            options.AddAdditionalCapability("appium:connectHardwareKeyboard", true);

            options.AddAdditionalCapability("appium:ensureWebviewsHavePages", true);
            //capabilities.AddAdditionalCapability("appium:app", appPath);
            options.AddAdditionalCapability("appium:appPackage", "com.indiez.penguin.dash");
            options.AddAdditionalCapability("appium:appActivity", "com.unity3d.player.UnityPlayerActivityWithANRWatchDog");
            if (!isReset)
            {
                options.AddAdditionalCapability("noReset", "true");
                options.AddAdditionalCapability("fullReset", "false");
            } 
            appiumDriver = new AndroidDriver<AndroidElement>(serverUri, options);

            return appiumDriver;
        }

        public static AndroidDriver<AndroidElement> SetupBase(bool intoApp = false)
        {
            AndroidDriver<AndroidElement> appiumDriver;
            var serverUri = new Uri("http://127.0.0.1:4723/wd/hub");

            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "android");
            options.AddAdditionalCapability("appium:automationName", "uiautomator2");

            if (intoApp)
            {
                options.AddAdditionalCapability("appium:appPackage", "com.indiez.penguin.dash");
                options.AddAdditionalCapability("appium:appActivity", "com.unity3d.player.UnityPlayerActivityWithANRWatchDog");
            }
            appiumDriver = new AndroidDriver<AndroidElement>(serverUri, options);

            return appiumDriver;
        }
    }
}
