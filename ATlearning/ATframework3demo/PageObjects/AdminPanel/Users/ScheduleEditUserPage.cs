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
        private WebItem nameField =>
            new WebItem("//input[@name='NAME']", "Поле ввода имени");
        private WebItem lastnameField => 
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии");
        private WebItem emailField =>
            new WebItem("//input[@name='EMAIL']", "Поле ввода электронной почты");
        private WebItem passwordField =>
            new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля");
        private WebItem confirmPasswordField =>
            new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля");
        private WebItem roleList =>
            new WebItem("//select[@name='ROLE']", "Выпадающий список ролей");
        private WebItem deleteSubjectButton => 
            new WebItem("//button[contains(@id, 'delete_subject')]", "Кнопка удаления предмета из списка в форме редактирования преподавателя");
        private WebItem addSubjectButton => new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предметы");
        private WebItem groupList => new WebItem("//select[@name='GROUP']", "Выпадающий список групп");


        public ScheduleUsersPage DeleteUser()
        {
            DeleteObject();
            return new ScheduleUsersPage();
        }

        public void EditSubjects(List<ScheduleSubject> subjects) 
        {
            while (deleteSubjectButton.WaitElementDisplayed()) { 
                deleteSubjectButton.Click();
            }

            int iter = 0;
            foreach (var subject in subjects)
            {
                addSubjectButton.Click();
                new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }
        }

        public void EditGroup(ScheduleGroup group)
        {
            groupList.SelectListItemByText(group.Title);
        }

        public ScheduleUsersPage EditUser(ScheduleUser user)
        {
            nameField.SendKeys(user.FirstName);
            lastnameField.SendKeys(user.LastName);
            emailField.SendKeys(user.Email);
            passwordField.SendKeys(user.Password);
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
