using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities.Users;
using System.Transactions;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleUsersPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateUserPage CreateUser(ScheduleUser user)
        {
            CreateObject();
            return new ScheduleCreateUserPage();
        }

        public ScheduleUsersPage IsUserPresent(ScheduleUser user, bool shouldBePresent)
        {
            Log.Info($"Поиск пользователя {user.FirstName} в списке");
            IsObjectPresent(user.FirstName, shouldBePresent);
            return this;
        }

        public ScheduleEditUserPage OpenEditForm(ScheduleUser user)
        {
            OpenBaseEditForm(user.FirstName);
            return new ScheduleEditUserPage();
        }
    }
}
