using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities.Users;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteAdmin : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление пользователя-администратора", homePage => DeleteUser(homePage)));
            return caseCollection;
        }

        public void DeleteUser(ScheduleHomePage homePage) {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleUser user = new ScheduleAdmin(id);

            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            NotCase_CreateObjects
                // создаем пользователя
                .CreateUser(user, adminPanel)
                // открываем список пользователей
                .OpenUsersList()
                // открываем форму редактирования
                .OpenEditForm(user)
                // удаляем
                .DeleteUser()
                // проверяем, удален ли пользователь
                .IsUserPresent(user, false);
            return;
        }
    }
}
