using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.CreateForms;
using ATframework3demo.PageObjects.EditForms;
using System.Collections.ObjectModel;

namespace ATframework3demo.TestEntities
{
    public class Teacher : ScheduleUser
    {
        public Teacher()
            : base()
        {
            role = UserRole.Teacher;
        }

        public List<string> subjects { get; set; }

        public UserCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenUserList()
                    .OpenCreateUserForm()
                    .FillUserData(this)
                    .AddUser();
        }

        public TeacherEditForm AddTeachingSubject(AdminPanel adminPanel, Subject subject)
        {
            return adminPanel
                    .OpenUserList()
                    .OpenEditTeacherForm(this)
                    .AddSubject(subject)
                    .SaveChanges();
        }
    }
}
