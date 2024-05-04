using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class NotCase_CreateObjects
    {
        public ScheduleAdminPanel CreateClassroomType(ScheduleClassroomType type, ScheduleHomePage homePage)
        {
            homePage
                // открываем админ. панель
                .OpenAdminPanel()
                // открываем список типов аудиторий
                .OpenClassroomTypesList()
                // нажимаем добавить
                .CreateClassroomType()
                // заполняем поля, сохраняем
                .FillFields(type)
                // проверяем, есть ли тип в списке
                .IsClassroomTypePresent(type, true)
                // возвращяемся на админ. панель
                .Return();
            return new ScheduleAdminPanel();
        }

        public ScheduleAdminPanel CreateClassroom(ScheduleClassroom classroom, ScheduleHomePage homePage)
        {
            CreateClassroomType(classroom.Type, homePage)
                .OpenClassroomsList()
                .CreateClassroom()
                .FillFields(classroom)
                .IsClassroomPresent(classroom, true)
                .Return();
            return new ScheduleAdminPanel();
        }

        public ScheduleAdminPanel CreateSubject(ScheduleSubject subject, ScheduleHomePage homePage)
        {
            CreateClassroomType(subject.Type, homePage)
                .OpenSubjectsList()
                .CreateSubject()
                .FillFields(subject)
                .IsSubjectPresent(subject, true)
                .Return();
            return new ScheduleAdminPanel();
        }

        public ScheduleAdminPanel CreateGroup(ScheduleGroup group, ScheduleHomePage homePage)
        {
            ScheduleAdminPanel adminPanel = new ScheduleAdminPanel();
            foreach (var subject in group.Subjects)
            {
                adminPanel = CreateSubject(subject, homePage);
            }

            adminPanel
                .OpenGroupsList()
                .CreateGroup()
                .FillFields(group)
                .IsGroupPresent(group, true)
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateUser(ScheduleUser user, ScheduleHomePage homePage)
        {

            ScheduleAdminPanel adminPanel = new ScheduleAdminPanel();
            switch (user.Role) {
                case UserRole.Teacher:
                    foreach (var subject in user.Subjects)
                    {
                        adminPanel = CreateSubject(subject, homePage);
                    }
                    break;
                case UserRole.Student:
                    adminPanel = CreateGroup(user.Group, homePage);
                    break;
                case UserRole.Admin:
                    adminPanel = homePage.OpenAdminPanel();
                    break;
            }
            adminPanel
                .OpenUsersList()
                .CreateUser()
                .FillFields(user)
                .IsUserPresent(user, true)
                .Return();
            return adminPanel;
        }
    }
}
