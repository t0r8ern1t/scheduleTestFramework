using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Users;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Subjects
{
    public class ScheduleSubjectsPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateSubjectPage CreateSubject()
        {
            CreateObject();
            return new ScheduleCreateSubjectPage();
        }

        public ScheduleSubjectsPage IsSubjectPresent(ScheduleSubject subject, bool shouldBePresent)
        {
            IsObjectPresent(subject.Title, shouldBePresent);
            return this;
        }

        public ScheduleEditSubjectPage OpenEditForm(ScheduleSubject subject)
        {
            OpenBaseEditForm(subject.Title);
            return new ScheduleEditSubjectPage();
        }
    }
}
