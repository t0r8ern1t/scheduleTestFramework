using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Users;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public abstract class ScheduleBaseObjectsPage
    {
        public void CreateObject()
        {
            new WebItem("//a[@id='add-button']", "Кнопка Добавить").Click();
        }

        public void IsObjectPresent(string name, bool shouldBePresent)
        {
            new WebItem("//input[@id='search-input']", "Строка поиска").SendKeys(name);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            var myObject = new WebItem($"//div[contains(text(),'{name}')]", "Искомый объект");

            bool isPresent = Waiters.WaitForCondition(() => myObject.AssertTextContains(name, default), 2, 6,
    $"Ожидание появления строки '{name}'");

            if (shouldBePresent == isPresent)
            {
                if (isPresent)
                {
                    Log.Info($"Объект {name} найден");
                }
                else
                {
                    Log.Info($"Объект {name} удален");
                }
            }
            else
            {
                if (!isPresent)
                {
                    Log.Error($"Объект {name} не удален");
                }
                else
                {
                    Log.Error($"Объект {name} не найден");
                }
            }
        }

        public void OpenBaseEditForm(string name)
        {
            var searchbar = new WebItem("//input[@id='search-input']", "Строка поиска");
            searchbar.Clear();
            searchbar.SendKeys(name);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            var myObject = new WebItem($"//div[contains(text(),'{name}')]", "Искомый объект");
            bool isPresent = Waiters.WaitForCondition(() => myObject.AssertTextContains(name, default), 2, 6, $"Ожидание появления строки '{name}'");

            if (isPresent) myObject.Click();
            else Log.Error($"Объект {name} не найден");
        }

        public ScheduleAdminPanel Return()
        {
            new WebItem("//a[@href='/admin/']", "Кнопка Назад (переход в админ. панель)").Click();
            return new ScheduleAdminPanel();
        }
    }
}
