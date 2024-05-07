using ATframework3demo.TestEntities.Users;

namespace ATframework3demo.TestEntities
{
    public class ScheduleClass
    {
        public ScheduleSubject Subject { get; set; }
        public ScheduleClassroom Classroom { get; set; }
        public ScheduleGroup Group { get; set; }
        public ScheduleTeacher Teacher { get; set; }

        public WeekDay Day { get; set; }
        public int Number { get; set; }

        public ScheduleClass(ScheduleSubject subject, ScheduleClassroom classroom, ScheduleGroup group, ScheduleTeacher teacher, WeekDay day, int number) 
        {
            Subject = subject;
            Classroom = classroom;
            Group = group;
            Teacher = teacher;
            Day = day;
            Number = number;
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
