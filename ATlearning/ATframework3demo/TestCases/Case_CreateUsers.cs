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
            caseCollection.Add(new TestCase("Добавление нового преподавателя", homePage => CreateTeacher(homePage)));
            return caseCollection;
        }

        public void CreateTeacher(ScheduleHomePage homePage) {

            Teacher teacher = new Teacher { firstName = "FirstName" + DateTime.Now.Ticks
                , lastName = "LastName" + DateTime.Now.Ticks
                , login = "testLogin" + DateTime.Now.Ticks
                , password = "admin1"
                , email = "autotest@gmail.com"};

            bool isLoginedInCreatedUser = homePage
                //открыть админ панель
                .OpenAdminPanel()
                //открыть список пользователей
                .OpenUserList()
                //открыть форму добавления нового пользователя
                .OpenCreateUserForm()
                //заполнить поля
                .FillUserData(teacher)
                //сохранить
                .AddUser()
                //выйти из аккаунта
                .Logout()
                //открыть форму авторизации
                .OpenLoginPage()
                //войти в созданный аккаунт
                .Login(teacher)
                //проверить что вход выполнен
                .isLogined();

            if (!isLoginedInCreatedUser)
            {
                Log.Error("Вход в созданный аккаунт не выполнен");
            }
        }
    }
}
