using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using System.Security.Cryptography.X509Certificates;

namespace ATframework3demo.PageObjects.Lists
{
    public abstract class EntityList
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();
        public static WebItem SearchInput =>
            new WebItem("//input[@id='search-input']", "Строка поиска");

        public static WebItem SearchButton =>
            new WebItem("//a[@id='search-button']", "Кнопка поиска");

        public static WebItem AddButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления");

        public static WebItem EntityCard(string title) =>
            new WebItem($"//div[contains(text(), '{title}')]", $"Кнопка сущности {title}");

        public void SearchEntity(string searchText)
        {
            SearchInput.SendKeys(searchText);
            SearchButton.Click();
        }

        public bool IsEntityRepresented(string title)
        {
            SearchEntity(title);
            return EntityCard(title).WaitElementDisplayed();
        }
    }
}
