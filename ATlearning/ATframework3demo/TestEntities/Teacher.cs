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
        public Teacher(List<Subject> subjects)
            : base()
        {
            role = UserRole.Teacher;
            this.subjects = subjects;
        }

        public List<Subject> subjects { get; set; }

        public TeacherCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenUserList()
                    .OpenCreateTeacherForm()
                    .AddTeacher(this, subjects);
        }

        public TeacherEditForm AddTeachingSubjects(AdminPanel adminPanel, List<Subject> subjects)
        {
            return adminPanel
                    .OpenUserList()
                    .OpenEditTeacherForm(this)
                    .AddSubjects(subjects);
        }
    }
}
