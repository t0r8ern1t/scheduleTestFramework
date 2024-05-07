using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;
using ATframework3demo.TestEntities.Users;
using System.Xml.Linq;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleEditUserPage : ScheduleBaseEditPage
    {
        public static WebItem nameField =>
            new WebItem("//input[@name='NAME']", "Поле ввода имени");
        public static WebItem lastnameField => 
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии");
        public static WebItem emailField =>
            new WebItem("//input[@name='EMAIL']", "Поле ввода электронной почты");
        public static WebItem passwordField =>
            new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля");
        public static WebItem confirmPasswordField =>
            new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля");
        public static WebItem roleList =>
            new WebItem("//select[@name='ROLE']", "Выпадающий список ролей");

        public ScheduleUsersPage DeleteUser()
        {
            DeleteObject();
            return new ScheduleUsersPage();
        }

        public void EditSubjects(List<ScheduleSubject> subjects) 
        {
            WebItem deleteButton = new WebItem("//button[contains(@id, 'delete_subject')]", "Кнопка удаления предмета из списка в форме редактирования преподавателя");

            while (deleteButton.WaitElementDisplayed()) { 
                deleteButton.Click();
                deleteButton = new WebItem("//button[contains(@id, 'delete_subject')]", "Кнопка удаления предмета из списка в форме редактирования преподавателя");
            }

            int iter = 0;
            foreach (var subject in subjects)
            {
                new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предметы").Click();
                new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }
        }

        public void EditGroup(ScheduleGroup group)
        {
            new WebItem("//select[@name='GROUP']", "Выпадающий список групп в форме редактирования студента").SelectListItemByText(group.Title);
        }

        public ScheduleUsersPage EditUser(ScheduleUser user)
        {
            nameField.Clear();
            nameField.SendKeys(user.FirstName);
            lastnameField.Clear();
            lastnameField.SendKeys(user.LastName);
            emailField.Clear();
            emailField.SendKeys(user.Email);
            passwordField.Clear();
            passwordField.SendKeys(user.Password);
            confirmPasswordField.Clear();
            confirmPasswordField.SendKeys(user.Password);
            roleList.SelectListItemByText(user.GetRoleName());

            switch (user)
            {
                case ScheduleAdmin admin:
                    break;
                case ScheduleTeacher teacher:
                    EditSubjects(teacher.Subjects);
                    break;
                case ScheduleStudent student:
                    EditGroup(student.Group);
                    break;

            }
            Save();

            return new ScheduleUsersPage();
        }

        public void AreSubjectsCorrect(ScheduleTeacher teacher)
        {
            foreach (var subject in teacher.Subjects)
            {
                var myObject = new WebItem($"//div[contains(text(),'{subject.Title}')]", "Искомый предмет");

                if (!Waiters.WaitForCondition(() => myObject.WaitElementDisplayed(), 2, 6,
                    $"Ожидание появления строки '{subject.Title}'"))
                {
                    Log.Error($"Предмет {subject.Title} не отображается в списке предметов преподавателя");
                }
            }
            Log.Info("Все предметы отображаются корректно");
        }
    }
}
