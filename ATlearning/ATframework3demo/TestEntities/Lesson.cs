namespace ATframework3demo.TestEntities
{
    public class Lesson
    {
        public Lesson(DayOfWeek dayOfWeek, int lessonNumber, Subject subject, Audience audience, Teacher teacher, Group group)
        {
            this.dayOfWeek = dayOfWeek;
            number = lessonNumber;
            this.subject = subject;
            this.audience = audience;
            this.teacher = teacher;
            this.group = group;
        }

        public DayOfWeek dayOfWeek { get; set; }

        public int number { get; set; }

        public Subject subject { get; set; }

        public Teacher teacher { get; set; }

        public Audience audience { get; set; }

        public Group group { get; set; }

        public int GetNumberDayOfWeek()
        {
            return (int)dayOfWeek;
        }
    }
}
