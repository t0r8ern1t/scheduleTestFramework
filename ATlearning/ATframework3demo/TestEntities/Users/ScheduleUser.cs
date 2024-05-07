using ATframework3demo.TestEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATframework3demo.TestEntities.Users
{
    public abstract class ScheduleUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        protected ScheduleUser(UserRole role, string id)
        {
            FirstName = "FirstName" + id;
            LastName = "LastName" + id;
            Login = "testLogin" + id;
            Password = "admin1";
            Email = "test" + id + "@gmail.com";
            Role = role;
        }

        public string GetRoleName()
        {
            switch (Role)
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
