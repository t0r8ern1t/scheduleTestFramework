namespace ATframework3demo.TestEntities
{
    public class ScheduleGroup
    {
        public string Title { get; set; }
        public List<ScheduleSubject> Subjects { get; set; }

        public ScheduleGroup(string title, List<ScheduleSubject> subjects)
        {
            this.Title = title;
            this.Subjects = subjects;
        }

        public ScheduleGroup() 
        {
            string id = DateTime.Now.Ticks.ToString();
            this.Title = "group" + id;
            this.Subjects = new List<ScheduleSubject>
            {
                new ScheduleSubject()
            };
        }
    }
}
