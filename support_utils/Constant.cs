namespace TestAlttrashCSharp.support_utils
{
    public class Constant
    {
        public class Path
        {
            public const string cSplit = "e=ad_impression p=";
            public const string SdkVersionPath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[3]/android.view.View[7]/android.widget.TextView[2]";

            public const string ShowAdsBtnPath = "//android.widget.TextView[@text=\"Show ad\"]";
            public const string FailAdsBtnPath = "//android.widget.TextView[@text=\"Load ad\"]";
            // index =1
            public const string ItemAdManagerPath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[1]";
            public const string SdkAdManagerPath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[1]/android.view.View[1]/android.widget.TextView[3]";
            public const string AdapterAdManagerPath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[1]/android.view.View[1]/android.widget.TextView[4]";

            public const string ItemApplovinPath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[2]";

            public const string TabRV = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[3]";
            public const string TabFS = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[4]";
            public const string TabBN = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[5]";

            public const string TabRV5 = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[5]";
            public const string TabFS6 = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[6]";
            public const string TabBN7 = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View/android.view.View[7]";
            
            public const string DestroyBtnPath = "//android.widget.TextView[@text=\"Destroy\"]";
            public const string ContainerAdSourcePath = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View";

            public const string BtnLoadAdPath = "//android.widget.TextView[@text=\"Load ad\"]";

            public const string BtnSourceAdPath = "//android.view.View[@content-desc=\"Ad sources\"]";


            // Item AdsSource Path
            // {0} index item adsource
            // {1} 0 Title, 1 Non-binding, 2 Sdk version, 3 adapter version
            public const string AdSourceTitle = "//android.webkit.WebView[@text=\"test-suite\"]/android.view.View/android.view.View[{0}]/android.view.View/android.widget.TextView[{1}]";
        }
        public enum PlatformInfo
        {
            Android , Ios
        }
    }
}
