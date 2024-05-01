using System.Data;

namespace ATframework3demo.TestEntities
{
    public class ScheduleUser
    {
        public ScheduleUser()
        {
            firstName = "FirstName" + DateTime.Now.Ticks;
            lastName = "LastName" + DateTime.Now.Ticks;
            login = "testLogin" + DateTime.Now.Ticks;
            password = "admin1";
            email = "test" + DateTime.Now.Ticks + "@gmail.com";
        }

        public string login { get; set; }

        public string password { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        protected UserRole role { get; set; }

        public string GetRoleName()
        {
            switch (this.role)
            {
                case UserRole.Teacher:
                    return "Преподаватель";
                case UserRole.Student:
                    return "Студент";
                case UserRole.Admin:
                    return "Администратор";
                default:
                    return "";
            }
        }
    }
    public enum UserRole 
    {
        Teacher,
        Student,
        Admin
    };
}
