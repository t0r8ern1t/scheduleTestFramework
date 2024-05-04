using atFrameWork2.TestEntities;
using System.Reflection;

namespace ATframework3demo.TestEntities
{
    public class ScheduleSubject
    {
        public string Title {  get; set; }
        public SubjectType Type { get; set; }

        public ScheduleSubject(string title, SubjectType type)
        {
            this.Title = title;
            this.Type = type;
        }

        public ScheduleSubject()
        {
            this.Title = "Subject" + DateTime.Now.Ticks.ToString();
            this.Type = SubjectType.Lecture;
        }

        public string GetTypeName()
        {
            switch (this.Type)
            {
                case SubjectType.Online:
                    return "Онлайн";
                case SubjectType.Lecture:
                    return "Лекционная";
                case SubjectType.Practice:
                    return "Практическая";
                default:
                    return "";
            }
        }
    }

    public enum SubjectType
    { 
        Lecture,
        Practice,
        Online
    }
}
