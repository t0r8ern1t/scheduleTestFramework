using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.AdminPanel.Users
{
    public class ScheduleEditUserPage
    {
        public ScheduleUsersPage DeleteUser()
        {
            new WebItem("//button[@class='button ml-2 is-danger']", "Кнопка Удалить").Click();
            new WebItem("//button[@id='delete-button']", "Подтверждение удаления").Click();
            return new ScheduleUsersPage();
        }
    }
}
