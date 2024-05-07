namespace ATframework3demo.TestEntities
{
    public class ScheduleGroup
    {
        public string Title { get; set; }
        public List<ScheduleSubject> Subjects { get; set; }

        public ScheduleGroup(string id, List<ScheduleSubject> subjects)
        {
            Title = "Group" + id;
            Subjects = subjects;
        }
    }
}
