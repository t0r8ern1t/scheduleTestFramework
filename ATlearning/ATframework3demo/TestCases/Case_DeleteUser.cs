using atFrameWork2.BaseFramework;
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

        public void DeleteUser(ScheduleHomePage homePage) {
            ScheduleUser user = new ScheduleUser();
            homePage
                .OpenAdminPanel()
                .OpenUsersList()
                .CreateUser()
                .FillFields(user)
                .IsUserPresent(user, true)
                .OpenEditForm(user)
                .DeleteUser()
                .IsUserPresent(user, false);
            return;
        }
    }
}
