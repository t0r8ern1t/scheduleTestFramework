using ATframework3demo.PageObjects.AdminPanel.Groups;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using atFrameWork2.BaseFramework.LogTools;

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

        public ScheduleAdminPanel CreateUser(ScheduleAdminPanel adminPanel, bool isCheckNeeded = true)
        {
            Log.Info("Создание пользователя");
            if (isCheckNeeded)
            {
                switch (this)
                {
                    // если пользователь - преподаватель, проверяем существуют ли предметы, указанные в параметрах
                    // если нет - создаем
                    case ScheduleTeacher teacher:
                        adminPanel = teacher.CheckSubjectsForTeacher(adminPanel);
                        break;
                    // если пользователь - студент, проверяем, существует ли его группа
                    // если нет - создаем
                    case ScheduleStudent student:
                        adminPanel = student.CheckGroupForStudent(adminPanel);
                        break;
                    case ScheduleAdmin admin:
                        // если пользователь админ, все ок, продолжаем
                        break;
                }
            }

            adminPanel
                // открываем список пользователей
                .OpenUsersList()
                // нажимаем добавить
                .CreateUser(this)
                // заполням форму
                .FillFields(this)
                // проверяем, есть ли пользователь в списке
                .IsUserPresent(this, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }
    }

    public enum UserRole
    {
        Teacher,
        Student,
        Admin
    };
}
