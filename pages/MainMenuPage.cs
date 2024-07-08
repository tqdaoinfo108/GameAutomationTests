namespace alttrashcat_tests_csharp.pages
{
    public class MainMenuPage : BasePage
    {
        public MainMenuPage(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
        }

        public AltObject UpTutoVerButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/TutorialMenu/SafeArea/Tutorials/UpTuto/Text", timeout: 10); }
        public AltObject ReStartButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/IngameMenu/SafeArea/TopBar/InAppUpdateGroup/ButtonRestart", timeout: 10); }
        public AltObject SwipePopup { get => Driver.WaitForObject(By.PATH, "CharName", timeout: 10); }
        public AltObject NoGiveUpButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/PausePopup/SafeArea/Board/PanelButton/ButtonNo/Text (TMP)", timeout: 10); }
        public AltObject UpToTuIcon { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/TutorialMenu/SafeArea/Tutorials/UpTuto", timeout: 10); }
       
        public AltObject PauseIcon { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/IngameMenu/SafeArea/TopLeftGroup/ButtonPause", timeout: 10); }
        public AltObject YesGiveUpButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/PausePopup/SafeArea/Board/PanelButton/ButtonYes", timeout: 10); }
        public AltObject PlayGameButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/MainMenu/SafeArea/ButtonTapToStart", timeout: 10); }
        public AltObject SettingIcon { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Menu/MainMenu/SafeArea/TopBar/ButtonSetting", timeout: 10); }
        public AltObject FakeLevelTextArea { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/DebugGroup/PanelLevel/InputField Level", timeout: 10); }

        public AltObject FakeLevel { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/DebugGroup/PanelLevel/InputField Level/Text Area/Text", timeout: 10); }
        public AltObject FakeSubLevel { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/DebugGroup/PanelLevel/InputField SubLevel/Text Area/Text", timeout: 10); }
        public AltObject GoLevel  { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/DebugGroup/PanelLevel/GoLevelButton", timeout: 10); }
        public AltObject CloseSetting { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/Board/ButtonClose", timeout: 10); }
        public AltObject CloseRatingPopup { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/ButtonClose", timeout: 10); }
        public AltObject Rating5Star { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/PanelStar/ToggleStar (4)", timeout: 10); }
        public AltObject Rating1Star { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/PanelStar/ToggleStar (0)", timeout: 10); }
        public AltObject Rating2Star { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/PanelStar/ToggleStar (1)", timeout: 10); }
        public AltObject Rating3Star { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/PanelStar/ToggleStar (2)", timeout: 10); }
        public AltObject Rating4Star { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/FakeRatingPopup/SafeArea/Board/PanelStar/ToggleStar (3)", timeout: 10); }

       public AltObject TestSuiteButton { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/DebugGroup/LaunchTestSuiteButton/Text (TMP)", timeout: 10); }

        public AltObject TextVersion { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/Board/TextVersion", timeout: 120); }

        // mới
        public AltObject ButtonMale { get => Driver.WaitForObject(By.PATH, "/ParentControlCanvas/ParentControlDialog/InfoGroup/Toggle/MaleToggle", timeout: 10); }
        public AltObject ButtonDot { get => Driver.WaitForObject(By.PATH, "/ParentControlCanvas/ParentControlDialog/InfoGroup/Toggle/MaleToggle/Background/Dot", timeout: 10); }
        public AltObject ButtonOk { get => Driver.WaitForObject(By.PATH, "/ParentControlCanvas/ParentControlDialog/InfoGroup/OkButton", timeout: 10); }
        public AltObject ButtonAccept { get => Driver.WaitForObject(By.PATH, "/ParentControlCanvas/ParentControlDialog/AcceptPolicyPopup/AcceptButton", timeout: 10); }
        public AltObject ButtonAcceptAndPlay { get => Driver.WaitForObject(By.PATH, "/ParentControlCanvas/ParentControlDialog/ParentAcceptPopup/ParentAcceptBtn", timeout: 10); }
        public AltObject ButtonXOfSubs { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SubcriptionPopup/SafeArea/Board/ButtonClose", timeout: 10); }
        public AltObject ButtonEditConsent { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/Board/PanelToggle/ButtonEditConsent", timeout: 10); }
        public AltObject ButtonToggleDoNotSell { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/Board/PanelToggle/ToggleDoNotSell", timeout: 10); }
        public AltObject ButtonCheckmark { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/SettingPopup/SafeArea/Board/PanelToggle/ToggleDoNotSell/Background/Checkmark", timeout: 10); }
        public AltObject ButtonWatchAds { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/ShopMenu/SafeArea/Scroll View/Viewport/Content/GoldGroup/PanelGoldenChest/ButtonWatchAds", timeout: 10); }
        public AltObject ButtonXShop { get => Driver.WaitForObject(By.PATH, "/Managers/UIManager/UI/Popup/ShopMenu/SafeArea/TopBar/ButtonClose", timeout: 10); }

        public void SwipeSkipGuide()
        {
            // thay đổi toạ độ vector 2 điểm
            Driver.Swipe(new AltVector2(540, 1566), new AltVector2(540, 1200), wait: true);
            
        }
        
        public bool IsUpToTuIconAvailiable()
        {
            return false;
        }
       
    }
}