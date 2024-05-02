using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class AdminPanel
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem UserListButton =>
            new WebItem("//a[@href=\"/admin/#user\"]", "Кнопка перехода к списку пользователей");

        public static WebItem SubjectListButton =>
            new WebItem("//a[@href=\"/admin/#subject\"]", "Кнопка перехода к списку предметов");

        public static WebItem GroupListButton =>
            new WebItem("//a[@href=\"/admin/#group\"]", "Кнопка перехода к списку групп");

        public static WebItem AudienceListButton =>
            new WebItem("//a[@href=\"/admin/#audience\"]", "Кнопка перехода к списку групп");

        public UserList OpenUserList()
        {
            UserListButton.Click();
            return new UserList();
        }

        public SubjectList OpenSubjectList()
        {
            SubjectListButton.Click();
            return new SubjectList();
        }

        public AudienceList OpenAudienceList()
        {
            AudienceListButton.Click();
            return new AudienceList();
        }

        public GroupList OpenGroupList()
        {
            GroupListButton.Click();
            return new GroupList();
        }
    }
}
