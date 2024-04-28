using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_SmartSchedule_Admin : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление нового преподавателя", homePage => CreateNewTeacher(homePage)));
            return caseCollection;
        }

        public void CreateNewTeacher(ScheduleHomePage homePage) {

            Teacher teacher = new Teacher { firstName = "FirstName" + DateTime.Now.Ticks
                , lastName = "LastName" + DateTime.Now.Ticks
                , login = "testLogin" + DateTime.Now.Ticks
                , password = "admin1"
                , email = "autotest@gmail.com"};

            bool isLoginedInCreatedUser = homePage
                .OpenAdminPanel()
                .OpenUserList()
                .OpenCreateUserForm()
                .FillUserData(teacher)
                .AddUser()
                .Logout()
                .OpenLoginPage()
                .Login(teacher)
                .isLogined();

            if (!isLoginedInCreatedUser)
            {
                Log.Error("Вход в созданный аккаунт не выполнен");
            }
        }
    }
}
