namespace ATframework3demo.TestEntities.Users
{
    public class ScheduleStudent : ScheduleUser
    {
        public ScheduleGroup Group { get; set; }

        public ScheduleStudent(string id, ScheduleGroup group) : base(UserRole.Student, id) 
        { 
            Group = group;
        }
    }
}
