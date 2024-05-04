using atFrameWork2.TestEntities;

namespace ATframework3demo.TestEntities
{
    public class ScheduleClass
    {
        public ScheduleSubject Subject { get; set; }
        public ScheduleClassroom Classroom { get; set; }
        public ScheduleGroup Group { get; set; }
        public ScheduleUser Teacher { get; set; }

        public WeekDay Day { get; set; }
        public int Number { get; set; }

        public ScheduleClass(ScheduleSubject subject, ScheduleClassroom classroom, ScheduleGroup group, ScheduleUser teacher, WeekDay day, int number) 
        {
            this.Subject = subject;
            this.Classroom = classroom;
            this.Group = group;
            this.Teacher = teacher;
            this.Day = day;
            this.Number = number;
        }

        public enum WeekDay
        {
            Monday = 1, 
            Tuesday = 2, 
            Wednesday = 3, 
            Thursday = 4, 
            Friday = 5, 
            Saturday = 6
        }
    }
}
