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
        }

        public void MakeAdminUser(string id)
        {
            this.FirstName = "FirstName" + id;
            this.LastName = "LastName" + id;
            this.Login = "testLogin" + id;
            this.Password = "admin1";
            this.Email = "test" + id + "@gmail.com";
            this.Role = UserRole.Admin;
        }

        public void MakeTeacherUser(string id, List<ScheduleSubject> subjects)
        {
            this.FirstName = "FirstName" + id;
            this.LastName = "LastName" + id;
            this.Login = "testLogin" + id;
            this.Password = "admin1";
            this.Email = "test" + id + "@gmail.com";
            this.Role = UserRole.Teacher;
            this.Subjects = subjects;
        }

        public void MakeStudentUser(string id, ScheduleGroup group)
        {
            this.FirstName = "FirstName" + id;
            this.LastName = "LastName" + id;
            this.Login = "testLogin" + id;
            this.Password = "admin1";
            this.Email = "test" + id + "@gmail.com";
            this.Role = UserRole.Admin;
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
