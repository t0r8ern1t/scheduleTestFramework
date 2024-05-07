namespace ATframework3demo.TestEntities.Users
{
    public class ScheduleAdmin : ScheduleUser
    {
        public ScheduleAdmin(string id) : base(UserRole.Admin, id) { }
    }
}
