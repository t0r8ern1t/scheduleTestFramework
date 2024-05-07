namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroomType
    {
        public string Title { get; set; }

        public ScheduleClassroomType(string id)
        { 
            Title = "Type" + id;
        }
    }
}
