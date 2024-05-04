using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel.Groups;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.PageObjects.AdminPanel.Users;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleAdminPanel
    {
        public static WebItem SubjectsButton =>
    new WebItem("//a[@href='/admin/#subject']", "Кнопка Предметы");
        public static WebItem UsersButton =>
    new WebItem("//a[@href='/admin/#user']", "Кнопка Пользователи");
        public static WebItem GroupsButton =>
    new WebItem("//a[@href='/admin/#group']", "Кнопка Группы");
        public static WebItem ClassroomsButton =>
    new WebItem("//a[@href='/admin/#audience']", "Кнопка Аудитории");
        public static WebItem ClasroomTypesButton =>
    new WebItem("//a[@href='/admin/#audienceType']", "Кнопка Типы аудиторий");

        public ScheduleUsersPage OpenUsersList()
        {
            UsersButton.Click();
            return new ScheduleUsersPage();
        }

        public ScheduleSubjectsPage OpenSubjectsList()
        {
            SubjectsButton.Click();
            return new ScheduleSubjectsPage();
        }

        public ScheduleGroupsPage OpenGroupsList()
        {
            GroupsButton.Click();
            return new ScheduleGroupsPage();
        }

        public ScheduleClassroomsPage OpenClassroomsList()
        {
            ClassroomsButton.Click();
            return new ScheduleClassroomsPage();
        }

        public ScheduleClassroomTypesPage OpenClassroomTypesList()
        {
            ClasroomTypesButton.Click();
            return new ScheduleClassroomTypesPage();
        }
    }
}
