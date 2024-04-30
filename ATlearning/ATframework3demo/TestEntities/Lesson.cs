namespace ATframework3demo.TestEntities
{
    public class Lesson
    {
        public Lesson(DayOfWeek dayOfWeek, int number, Subject subject, Audience audience, Teacher teacher, Groupe groupe)
        {
            this.dayOfWeek = dayOfWeek;
            this.number = number;
            this.subject = subject;
            this.audience = audience;
            this.teacher = teacher;
            this.groupe = groupe;
        }

        public DayOfWeek dayOfWeek { get; set; }

        public int number { get; set; }

        public Subject subject { get; set; }

        public Teacher teacher { get; set; }

        public Audience audience { get; set; }

        public Groupe groupe { get; set; }

        public int GetNumberDayOfWeek()
        {
            return (int)dayOfWeek + 1;
        }
    }
}
