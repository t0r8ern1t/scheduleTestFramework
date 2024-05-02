using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestEntities
{
    public class Subject
    {
        public Subject(AudienceType audienceType = AudienceType.Lecture)
        {
            title = "Subject" + DateTime.Now.Ticks;
            this.audienceType = audienceType;
        }

        public string title { get; set; }

        public AudienceType audienceType { get; set; }

        public string GetAudienceTypeName()
        {
            switch (this.audienceType)
            {
                case AudienceType.Lecture:
                    return "Лекционная";
                case AudienceType.Practice:
                    return "Практическая";
                case AudienceType.Online:
                    return "Онлайн";
                default:
                    return "";
            }
        }

        public SubjectCreateForm Create(ScheduleHomePage homePage)
        {
            return homePage
                    .OpenAdminPanel()
                    .OpenSubjectList()
                    .OpenSubjectCreateForm()
                    .AddSubject(this);
        }
    }
}
