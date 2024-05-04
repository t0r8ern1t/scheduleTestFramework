using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleEditUserPage : ScheduleBaseEditPage
    {
        public ScheduleUsersPage DeleteUser()
        {
            DeleteObject();
            return new ScheduleUsersPage();
        }

        public ScheduleUsersPage EditUser(ScheduleUser editedUser)
        {
            new WebItem("//input[@name='NAME']", "Поле ввода имени").SendKeys(editedUser.FirstName);
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии").SendKeys(editedUser.LastName);
            new WebItem("//input[@name='EMAIL']", "Поле ввода электронной почты").SendKeys(editedUser.Email);
            new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля").SendKeys(editedUser.Password);
            new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля").SendKeys(editedUser.Password);
            new WebItem("//select[@name='ROLE']", "Выпадающий список ролей").SelectListItemByText(editedUser.GetRoleName());

            SaveChanges();
            return new ScheduleUsersPage();
        }
    }
}
