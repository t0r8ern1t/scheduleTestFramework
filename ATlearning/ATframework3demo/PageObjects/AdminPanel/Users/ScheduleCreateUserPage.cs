using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using ATframework3demo.TestEntities.Users;
using System.Drawing.Text;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleCreateUserPage : ScheduleBaseCreatePage
    {
        private WebItem groupList => new WebItem("//select[@name='GROUP']", "Выпадающий список групп");
        private WebItem addSubjectButton => new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предмет");
        private WebItem loginField => new WebItem("//input[@name='LOGIN']", "Поле ввода логина");
        private WebItem namefield => new WebItem("//input[@name='NAME']", "Поле ввода имени");
        private WebItem lastNameField => new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии");
        private WebItem emailField => new WebItem("//input[@name='EMAIL']", "Поле ввода электронной почты");
        private WebItem passwordField => new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля");
        private WebItem confirmPasswordField => new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля");
        private WebItem rolesList => new WebItem("//select[@name='ROLE']", "Выпадающий список ролей");

        public void AddGroup(ScheduleGroup group)
        {
            groupList.SelectListItemByText(group.Title);
        }

        public void AddSubjects(List<ScheduleSubject> subjects)
        {
            int iter = 0;
            foreach (var subject in subjects)
            {
                addSubjectButton.Click();
                new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }
        }
         public ScheduleUsersPage FillFields(ScheduleUser user)
        {
            loginField.SendKeys(user.Login);
            namefield.SendKeys(user.FirstName);
            lastNameField.SendKeys(user.LastName);
            emailField.SendKeys(user.Email);
            passwordField.SendKeys(user.Password);
            confirmPasswordField.SendKeys(user.Password);
            rolesList.SelectListItemByText(user.GetRoleName());

            switch (user)
            {
                case ScheduleAdmin admin:
                    break;
                case ScheduleTeacher teacher:
                    AddSubjects(teacher.Subjects);
                    break;
                case ScheduleStudent student:
                    AddGroup(student.Group);
                    break;
            }
            Save();
            return new ScheduleUsersPage();
        }
    }
}