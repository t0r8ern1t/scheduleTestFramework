namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroom
    {
        public string Title { get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleClassroom(ScheduleClassroomType type)
        {
            Title = "Room" + new Random().Next(100000);
            Type = type;
        }
    }
}
