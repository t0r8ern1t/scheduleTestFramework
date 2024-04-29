namespace ATframework3demo.TestEntities
{
    public class Class
    {
        public DayOfWeek dayOfWeek { get; set; }

        public int number { get; set; }

        public Subject subject { get; set; }

        public Teacher teacher { get; set; }

        public Audience audience { get; set; }

        public Groupe groupe { get; set; }
    }

    public enum DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };
}
