namespace ATframework3demo.TestEntities.Users
{
    public class ScheduleTeacher : ScheduleUser
    {
        public List<ScheduleSubject> Subjects { get; set; }

        public ScheduleTeacher(string id, List<ScheduleSubject> subjects) : base(UserRole.Teacher, id)
        {
            Subjects = subjects;
        }
    }
}
