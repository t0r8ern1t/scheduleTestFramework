using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.CreateForms;

namespace ATframework3demo.TestEntities
{
    public class Subject
    {
        public Subject(AudienceType audienceType)
        {
            title = "Subject" + DateTime.Now.Ticks;
            this.audienceType = audienceType;
        }

        public string title { get; set; }

        public AudienceType audienceType { get; set; }

        public SubjectCreateForm Create(ScheduleHomePage homePage)
        {
            return homePage
                    .LeftMenu.OpenAdminPanel()
                    .OpenSubjectList()
                    .OpenSubjectCreateForm()
                    .AddSubject(this);
        }
    }
}
