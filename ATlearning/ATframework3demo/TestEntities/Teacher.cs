﻿using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.CreateForms;
using ATframework3demo.PageObjects.EditForms;
using System.Collections.ObjectModel;

namespace ATframework3demo.TestEntities
{
    public class Teacher : ScheduleUser
    {
        public Teacher()
            : base()
        {
            role = UserRole.Teacher;
        }

        public List<string> subjects { get; set; }

        public UserCreateForm Create(ScheduleHomePage homePage)
        {
            return homePage
                    .LeftMenu.OpenAdminPanel()
                    .OpenUserList()
                    .OpenCreateUserForm()
                    .FillUserData(this)
                    .AddUser();
        }

        public TeacherEditForm AddTeachingSubject(ScheduleHomePage homePage, Subject subject)
        {
            return homePage
                    .LeftMenu.OpenAdminPanel()
                    .OpenUserList()
                    .OpenEditTeacherForm(this)
                    .AddSubject(subject)
                    .SaveChanges();
        }
    }
}
