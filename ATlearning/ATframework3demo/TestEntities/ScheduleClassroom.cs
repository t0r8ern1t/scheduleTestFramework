namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroom
    {
        public string Title { get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleClassroom(string title, ScheduleClassroomType type)
        {
            this.Title = title;
            this.Type = type;
        }

        public ScheduleClassroom() 
        {
            string id = DateTime.Now.Ticks.ToString();
            this.Title = "Classroom" + id;
            this.Type = new ScheduleClassroomType();
        }
    }
}
