using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Users;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public abstract class ScheduleBaseObjectsPage
    {
        protected WebItem addButton => new WebItem("//a[@id='add-button']", "Кнопка Добавить");
        protected WebItem searchBar => new WebItem("//input[@id='search-input']", "Строка поиска");
        protected WebItem searchButton => new WebItem("//a[@id='search-button']", "Кнопка Искать");
        protected WebItem backButton => new WebItem("//a[@href='/admin/']", "Кнопка Назад (переход в админ. панель)");

        protected void CreateObject()
        {
            addButton.Click();
        }

        protected void Search(string name)
        {
            searchBar.SendKeys(name);
            searchButton.Click();
        }

        protected void IsObjectPresent(string name, bool shouldBePresent)
        {
            Search(name);
            var myObject = new WebItem($"//div[contains(text(),'{name}')]", "Искомый объект");

            bool isPresent = Waiters.WaitForCondition(() => myObject.WaitElementDisplayed(), 2, 6,
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
                    Log.Error($"Объект {name} не найден");
                }
                else
                {
                    Log.Error($"Объект {name} не удален");
                }
            }
        }

        protected bool FindObject(string name) 
        {
            Search(name);
            var myObject = new WebItem($"//div[contains(text(),'{name}')]", "Искомый объект");

            return Waiters.WaitForCondition(() => myObject.WaitElementDisplayed(), 2, 6,
                $"Ожидание появления строки '{name}'");
        }

        protected void OpenBaseEditForm(string name)
        {
            Search(name);
            var myObject = new WebItem($"//div[contains(text(),'{name}')]", "Искомый объект");
            bool isPresent = Waiters.WaitForCondition(() => myObject.AssertTextContains(name, default), 2, 6, $"Ожидание появления строки '{name}'");

            if (isPresent) 
                myObject.Click();
            else
                Log.Error($"Объект {name} не найден");
        }

        public ScheduleAdminPanel Return()
        {
            backButton.Click();
            return new ScheduleAdminPanel();
        }
    }
}
