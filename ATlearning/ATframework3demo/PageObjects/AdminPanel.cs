using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class AdminPanel : ScheduleHomePage
    {
        public static WebItem UserListButton =>
            new WebItem("//a[@href=\"/admin/#user\"]", "Кнопка перехода к списку пользователей");

        public UserList OpenUserList()
        {
            UserListButton.Click();
            return new UserList();
        }
    }
}
