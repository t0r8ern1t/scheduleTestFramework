﻿using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_SomeCase : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление пользователя", homePage => DeleteUser(homePage)));
            return caseCollection;
        }

        public ScheduleUser GenerateUser()
        {
            string id = DateTime.Now.Ticks.ToString();
            string firstName = "FirstName" + id;
            string lastName = "LastName" + id;
            string login = "testLogin" + id;
            string password = "admin1";
            string email = "test" + id + "@gmail.com";
            UserRole role = UserRole.Admin;
            return new ScheduleUser(login, password, firstName, lastName, email, role);
        }

        public void DeleteUser(ScheduleHomePage homePage) {
            ScheduleUser user = GenerateUser();
            ScheduleUser editedUser = GenerateUser();
            homePage
                .OpenAdminPanel()
                .OpenUsersList()
                .CreateUser()
                .FillFields(user)
                .IsUserPresent(user, true)
                .OpenEditForm(user)
                .DeleteUser()
                .IsUserPresent(editedUser, false);
            return;
        }
    }
}
