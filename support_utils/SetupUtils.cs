using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Linq;
using TestAlttrashCSharp.Model;
using static TestAlttrashCSharp.support_utils.Constant;
using By = OpenQA.Selenium.By;

namespace TestAlttrashCSharp.support_utils
{
    public class SetupUtils
    {
        public PlatformInfo _platformInfo;

        public bool isReset;

        // Cấu hình này mặc định không cần chỉnh sửa

        public SetupUtils(PlatformInfo platformInfo, bool isReset)
        {
            _platformInfo = platformInfo;
            this.isReset = isReset; 
        }

        /// <summary>
        ///     Setup
        /// </summary>
        /// <returns></returns>
        public dynamic GetAppiumDriver()
        {
            switch (_platformInfo)
            {
                case PlatformInfo.Android:

                    return SetupAndroid.Setup(isReset: isReset);

                case PlatformInfo.Ios:
                    return SetupIos.Setup();

                default:
                    Console.WriteLine("Chúng tôi chưa hỗ trợ nền tảng này !");
                    return null;
            }
        }

        public dynamic GetAppiumDriverBase(bool intoApp)
        {
            switch (_platformInfo)
            {
                case PlatformInfo.Android:

                    return SetupAndroid.SetupBase(intoApp: intoApp);

                case PlatformInfo.Ios:
                    return SetupIos.Setup();

                default:
                    Console.WriteLine("Chúng tôi chưa hỗ trợ nền tảng này !");
                    return null;
            }
        }
        public static List<AndroidElement> TryFindElements(AndroidDriver<AndroidElement> driverAppium, string path)
        {
            try
            {
                return driverAppium.FindElements(By.XPath(path)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public static AndroidElement TryFindElement(AndroidDriver<AndroidElement> driverAppium, string path)
        {
            try
            {
                return driverAppium.FindElement(By.XPath(path));
            }
            catch
            {
                return null;
            }
        }

        public static void ClickCustom(AndroidDriver<AndroidElement> driverAppium, string sourcePath)
        {
            var e = driverAppium.FindElement(By.XPath(sourcePath));
            var finger = new PointerInputDevice(PointerKind.Touch);
            var tapPoint = new Point(e.Location.X, e.Location.Y);
            var tap = new ActionSequence(finger);
            tap.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, tapPoint.X + e.Rect.Width / 2, tapPoint.Y + e.Rect.Height / 2, TimeSpan.Zero));
            tap.AddAction(finger.CreatePointerDown(MouseButton.Left));
            tap.AddAction(finger.CreatePointerUp(MouseButton.Left));
            driverAppium.PerformActions(new List<ActionSequence> { tap });
        }

        public static void Swipe(AndroidDriver<AndroidElement> driverAppium, double startX, double startY, double endX, double endY)
        {
            // Create a TouchAction object
            TouchAction action = new TouchAction( driverAppium);

            // Build the swipe action: press at start, wait, move to end, release
            action
                .Press(startX, startY)
                .Wait(500) // Adjust wait time as needed
                .MoveTo(endX, endY)
                .Release()
                .Perform();
        }

        public static bool TryGetAdsAndReturn(AndroidDriver<AndroidElement> driverAppium, int indexTab = 0, int maxRetry = 5)
        {
            bool isResult = false;
            string liveAdPath = "//android.widget.TextView[@text=\"Test ad\"]";

            var liveAdPathElement = SetupUtils.TryFindElement(driverAppium, liveAdPath);

            List<string> listTabs = liveAdPathElement == null ? new() { Path.TabRV, Path.TabFS, Path.TabBN } : new() { Path.TabRV5, Path.TabFS6, Path.TabBN7 }; 

            string paths = listTabs[indexTab];
            int countPressBtnLoadAd = 0;
            foreach (string path in new List<string>() { paths })
            {
                if (isResult) break;
                var tab = SetupUtils.TryFindElement(driverAppium, path);
                
                if (tab == null) continue;
                SetupUtils.ClickCustom(driverAppium, path);
                Thread.Sleep(3000);

                while (countPressBtnLoadAd < maxRetry)
                {
                    var btnShowAds = SetupUtils.TryFindElement(driverAppium, Path.ShowAdsBtnPath);
                    if (btnShowAds != null)
                    {
                        btnShowAds.Click();
                        isResult = true;
                        break;
                    }

                    _ = driverAppium.PageSource;
                    _ = driverAppium.PageSource;

                    // Chỉ cho banner ad
                    var destroyBtn = SetupUtils.TryFindElement(driverAppium, Path.DestroyBtnPath);
                    if (destroyBtn != null)
                    {
                        isResult = true;
                        Thread.Sleep(5000);
                        break;
                    }

                    var btnLoadAd = SetupUtils.TryFindElement(driverAppium, Path.FailAdsBtnPath);
                    if (btnLoadAd != null)
                    {
                        countPressBtnLoadAd++;
                        btnLoadAd.Click();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            }

            return isResult;
        }
        public static bool isMatchAdimpression(List<string> logs, string ad_source, double valueMax)
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
        public static AdPlatformObject ReturnAdPlatformObject(List<string> logs)
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
