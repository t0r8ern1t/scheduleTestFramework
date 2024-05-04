using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel.Groups;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class NotCase_CreateObjects
    {
        public ScheduleAdminPanel CreateClassroomType(ScheduleClassroomType type, ScheduleAdminPanel adminPanel)
        {
            adminPanel
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
            return adminPanel;
        }

        public ScheduleAdminPanel CreateClassroom(ScheduleClassroom classroom, ScheduleAdminPanel adminPanel)
        {
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(classroom.Type))
            {
                classroomTypesList.Return();
                adminPanel = CreateClassroomType(classroom.Type, adminPanel);
            }
            adminPanel
                .OpenClassroomsList()
                .CreateClassroom()
                .FillFields(classroom)
                .IsClassroomPresent(classroom, true)
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateSubject(ScheduleSubject subject, ScheduleAdminPanel adminPanel)
        {
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(subject.Type))
            {
                classroomTypesList.Return();
                adminPanel = CreateClassroomType(subject.Type, adminPanel);
            }
            adminPanel
                .OpenSubjectsList()
                .CreateSubject()
                .FillFields(subject)
                .IsSubjectPresent(subject, true)
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateGroup(ScheduleGroup group, ScheduleAdminPanel adminPanel)
        {
            foreach (var subject in group.Subjects)
            {
                adminPanel = CreateSubject(subject, adminPanel);
            }

            adminPanel
                .OpenGroupsList()
                .CreateGroup()
                .FillFields(group)
                .IsGroupPresent(group, true)
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateUser(ScheduleUser user, ScheduleAdminPanel adminPanel)
        {
            switch (user.Role) {
                case UserRole.Teacher:
                    ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
                    foreach (var subject in user.Subjects)
                    {
                        if (!subjectsList.FindSubject(subject))
                        {
                            subjectsList.Return();
                            adminPanel = CreateSubject(subject, adminPanel);
                        }
                    }
                    break;
                case UserRole.Student:
                    ScheduleGroupsPage groupsList = adminPanel.OpenGroupsList();
                    if (!groupsList.FindGroup(user.Group))
                    {
                        groupsList.Return();
                        adminPanel = CreateGroup(user.Group, adminPanel);
                    }
                    break;
                case UserRole.Admin:
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
