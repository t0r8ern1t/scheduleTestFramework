using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using System.Transactions;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleUsersPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateUserPage CreateUser()
        {
            CreateObject();
            return new ScheduleCreateUserPage();
        }

        public ScheduleUsersPage IsUserPresent(ScheduleUser user, bool shouldBePresent)
        {
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
