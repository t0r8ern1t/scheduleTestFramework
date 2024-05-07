using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class PortalLeftMenu
    {
        public static WebItem OpenProfileButton =>
            new WebItem("//a[@href='/profile/']", "Кнопка перехода в профиль");

        public static WebItem LogoutButton =>
            new WebItem("//a[@href='/logout/']", "Кнопка выхода из учетной записи");

        public static WebItem LoginButton =>
            new WebItem("//a[@href='/login/']", "Кнопка входа в учетную записи");

        public static WebItem AdminPanelButton =>
            new WebItem("//a[@href='/admin/']", "Кнопка перехода в админ панель");

        public static WebItem SchedulingButton =>
            new WebItem("//a[@href='/scheduling/']", "Кнопка перехода к составлению расписания");

        public static WebItem BackToSchedule =>
            new WebItem("//a[@href='/']", "Кнопка перехода к расписанию");

        private static WebItem EntitySelectionButton =>
            new WebItem("//input[@id='entity-selection-button']", "Кнопка выбора сущности для отображения");

        private static WebItem GropeShowModeButton =>
            new WebItem("//ul[@id='schedule-display-entity-list']//child::a[contains(@href, 'group')]//ancestor::li"
                , "Кнопка выбора режима отображения по группе");

        private static WebItem AudienceShowModeButton =>
            new WebItem("//ul[@id='schedule-display-entity-list']/li//child::a[contains(@href, 'audience')]"
                , "Кнопка выбора режима отображения по аудитории");

        private static WebItem TeacherShowModeButton =>
            new WebItem("//ul[@id='schedule-display-entity-list']/li//child::a[contains(@href, 'teacher')]"
                , "Кнопка выбора режима отображения по преподавателю");

        private static WebItem ImportButton =>
            new WebItem("//a[@href='/import/']", "Кнопка перехода к импортированию расписания");

        public ScheduleHomePage Logout()
        {
            LogoutButton.Click();
            return new ScheduleHomePage();
        }

        public ScheduleLoginPage OpenLoginPage()
        {
            LoginButton.Click();
            return new ScheduleLoginPage();
        }

        public AdminPanel OpenAdminPanel()
        {
            AdminPanelButton.Click();
            return new AdminPanel();
        }

        public ScheduleHomePage OpenSchedule()
        {
            BackToSchedule.Click();
            return new ScheduleHomePage();
        }

        public ScheduleImportPage OpenImportPanel()
        {
            ImportButton.Click();
            return new ScheduleImportPage();
        }

        public bool isLogined()
        {
            return LogoutButton.WaitElementDisplayed();
        }
    }
}
