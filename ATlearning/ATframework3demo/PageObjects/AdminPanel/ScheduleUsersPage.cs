using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleUsersPage
    {
        public ScheduleCreateUserPage CreateUser()
        {
            new WebItem("//a[@id='add-button']", "Кнопка Добавить").Click();
            return new ScheduleCreateUserPage();
        }

        public ScheduleUsersPage IsUserPresent(ScheduleUser user, bool shouldBePresent)
        {
            new WebItem("//input[@id='search-input']", "Строка поиска").SendKeys(user.FirstName);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            var myUser = new WebItem($"//div[contains(text(),'{user.FirstName}')]", "Искомый пользователь");

            bool isPresent = Waiters.WaitForCondition(() => myUser.AssertTextContains(user.FirstName, default), 2, 6,
    $"Ожидание появления строки '{user.FirstName}'");

            if (shouldBePresent == isPresent)
            {
                if (isPresent)
                {
                    Log.Info($"Пользователь {user.FirstName} найден");
                }
                else
                {
                    Log.Info($"Пользователь {user.FirstName} удален");
                }
            }
            else
            {
                if (!isPresent)
                {
                    Log.Error($"Пользователь {user.FirstName} не удален");
                }
                else
                {
                    Log.Error($"Пользователь {user.FirstName} не найден");
                }
            }
            return this;
        }

        public ScheduleEditUserPage OpenEditForm(ScheduleUser user)
        {
            var searchbar = new WebItem("//input[@id='search-input']", "Строка поиска");
            searchbar.Clear();
            searchbar.SendKeys(user.FirstName);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            new WebItem($"//div[contains(text(),'{user.FirstName}')]", "Искомый пользователь").Click();
            return new ScheduleEditUserPage();
        }
    }
}
