namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroomType
    {
        public string Title { get; set; }

        public ScheduleClassroomType(string title)
        { 
            this.Title = title;
        }

        public ScheduleClassroomType() 
        { 
            this.Title = "Type" + DateTime.Now.Ticks.ToString();
        }

    }
}
