using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;

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
            ScheduleUser user = new ScheduleUser();
            NotCase_CreateObjects sys = new NotCase_CreateObjects();

            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            sys
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
