using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.PageObjects.AdminPanel;

namespace ATframework3demo.TestEntities.Users
{
    public class ScheduleTeacher : ScheduleUser
    {
        public List<ScheduleSubject> Subjects { get; set; }

        public ScheduleTeacher(string id, List<ScheduleSubject> subjects) : base(UserRole.Teacher, id)
        {
            Subjects = subjects;
        }

        public ScheduleAdminPanel CheckSubjectsForTeacher(ScheduleAdminPanel adminPanel)
        {
            ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
            foreach (var subject in this.Subjects)
            {
                if (!subjectsList.FindSubject(subject))
                {
                    subject.CreateSubject(subjectsList.Return());
                }
            }
            return subjectsList.Return();
        }
    }
}
