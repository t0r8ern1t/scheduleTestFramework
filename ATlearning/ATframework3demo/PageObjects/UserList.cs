using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

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

        public UserEditForm OpenEditUserForm(ScheduleUser user)
        {
            new WebItem($"//div[contains(text(), '{user.firstName}') and contains(text(), '{user.lastName}')]"
                , $"Кнопка пользователя {user.login}")
                .Click();
            return new UserEditForm();
        }

        public TeacherEditForm OpenEditTeacherForm(ScheduleUser user)
        {
            new WebItem($"//div[contains(text(), '{user.firstName}') and contains(text(), '{user.lastName}')]"
                , $"Кнопка пользователя {user.login}")
                .Click();
            return new TeacherEditForm();
        }
    }
}
