using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
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
            Log.Info("Создание типа аудитории");
            adminPanel
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
            Log.Info("Создание аудитории");
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(classroom.Type))
            {
                adminPanel = CreateClassroomType(classroom.Type, classroomTypesList.Return());
            }
            else
            {
                adminPanel = classroomTypesList.Return();
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
            Log.Info("Создание предмета");
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(subject.Type))
            {
                adminPanel = CreateClassroomType(subject.Type, classroomTypesList.Return());
            }
            else 
            {
                adminPanel = classroomTypesList.Return();  
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
            Log.Info("Создание группы");
            ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
            foreach (var subject in group.Subjects)
            { 
                if (!subjectsList.FindSubject(subject))
                {
                    adminPanel = CreateSubject(subject, subjectsList.Return());
                }
            }
            adminPanel = subjectsList.Return();

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
            Log.Info("Создание пользователя");
            switch (user.Role) {
                case UserRole.Teacher:
                    ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
                    foreach (var subject in user.Subjects)
                    {
                        if (!subjectsList.FindSubject(subject))
                        {
                            adminPanel = CreateSubject(subject, subjectsList.Return());
                        }
                    }
                    adminPanel = subjectsList.Return();
                    break;
                case UserRole.Student:
                    ScheduleGroupsPage groupsList = adminPanel.OpenGroupsList();
                    if (!groupsList.FindGroup(user.Group))
                    {
                        groupsList.Return();
                        adminPanel = CreateGroup(user.Group, adminPanel);
                    }
                    adminPanel = groupsList.Return();
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

        public ScheduleHomePage CreateClass(ScheduleClass myclass, ScheduleAdminPanel adminPanel) 
        {
            Log.Info("Создание пары");
            adminPanel = CreateSubject(myclass.Subject, adminPanel);
            adminPanel = CreateClassroom(myclass.Classroom, adminPanel);
            adminPanel = CreateGroup(myclass.Group, adminPanel);
            adminPanel = CreateUser(myclass.Teacher, adminPanel);

            adminPanel
                .OpenHomePage()
                .ChooseGroup(myclass)
                .AddClass(myclass)
                .FillFields(myclass)
                .IsClassPresent(myclass, true);

            return new ScheduleHomePage();
        }
    }
}
