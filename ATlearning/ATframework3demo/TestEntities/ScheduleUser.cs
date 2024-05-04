using ATframework3demo.TestEntities;
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
        public UserRole Role { get; set; }

        public List<ScheduleSubject>? Subjects { get; set; }
        public ScheduleGroup? Group { get; set; }

        public ScheduleUser()
        {
            string id = DateTime.Now.Ticks.ToString();
            this.FirstName = "FirstName" + id;
            this.LastName = "LastName" + id;
            this.Login = "testLogin" + id;
            this.Password = "admin1";
            this.Email = "test" + id + "@gmail.com";
            this.Role = UserRole.Admin;
            this.Subjects = new List<ScheduleSubject>();
        }

        public void ScheduleAdminUser(string login, string password, string firstName, string lastName, string email)
        {
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = UserRole.Admin;
        }

        public void ScheduleTeacherUser(string login, string password, string firstName, string lastName, string email, List<ScheduleSubject> subjects)
        {
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = UserRole.Teacher;
            this.Subjects = subjects;
        }

        public void ScheduleStudentUser(string login, string password, string firstName, string lastName, string email, ScheduleGroup group)
        {
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = UserRole.Student;
            this.Group = group;
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
