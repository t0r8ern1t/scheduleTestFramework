using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class UserList : ScheduleHomePage
    {
        public static WebItem AddUserButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления пользователя");

       public UserCreateForm OpenCreateUserForm()
        {
            AddUserButton.Click();
            return new UserCreateForm();
        }
    }
}
