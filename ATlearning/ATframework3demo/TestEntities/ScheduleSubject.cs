using atFrameWork2.TestEntities;
using System.Reflection;

namespace ATframework3demo.TestEntities
{
    public class ScheduleSubject
    {
        public string Title {  get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleSubject(string id, ScheduleClassroomType type)
        {
            Title = "Subject" + id;
            Type = type;
        }
    }
}
