using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    public class ScheduleUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        protected UserRole Role { get; set; }

        public ScheduleUser(string login, string password, string firstName, string lastName, string email, UserRole role)
        {
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = role;
        }

        public string GetRoleName()
        {
            switch (this.Role)
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
