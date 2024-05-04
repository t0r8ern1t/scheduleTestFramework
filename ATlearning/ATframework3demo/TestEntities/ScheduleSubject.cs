using atFrameWork2.TestEntities;
using System.Reflection;

namespace ATframework3demo.TestEntities
{
    public class ScheduleSubject
    {
        public string Title {  get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleSubject(string title, ScheduleClassroomType type)
        {
            this.Title = title;
            this.Type = type;
        }

        public ScheduleSubject()
        {
            string id = DateTime.Now.Ticks.ToString();
            this.Title = "Subject" + id;
            this.Type = new ScheduleClassroomType();
        }
    }
}
