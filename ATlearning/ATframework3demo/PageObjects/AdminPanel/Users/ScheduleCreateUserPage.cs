using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleCreateUserPage
    {
        public ScheduleUsersPage FillFields(ScheduleUser user)
        {
            new WebItem("//input[@name='LOGIN']", "Поле ввода логина").SendKeys(user.Login);
            new WebItem("//input[@name='NAME']", "Поле ввода имени").SendKeys(user.FirstName);
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии").SendKeys(user.LastName);
            new WebItem("//input[@name='EMAIL']", "Поле ввода электронной почты").SendKeys(user.Email);
            new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля").SendKeys(user.Password);
            new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля").SendKeys(user.Password);
            new WebItem("//select[@name='ROLE']", "Выпадающий список ролей").SelectListItemByText(user.GetRoleName());

            if (user.Role == UserRole.Teacher)
            {
                int iter = 0;
                foreach (var subject in user.Subjects)
                {
                    new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предметы").Click();
                    new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                    iter++;
                }
            }
            else if (user.Role == UserRole.Student)
            {
                new WebItem("//select[@name='GROUP']", "Выпадающий список групп").SelectListItemByText(user.Group.Title);
            }

                new WebItem("//button[@type='submit']", "Кнопка Добавить").Click();

            new WebItem("//a[@id='back-button']", "Кнопка Назад").Click();

            return new ScheduleUsersPage();
        }
    }
}