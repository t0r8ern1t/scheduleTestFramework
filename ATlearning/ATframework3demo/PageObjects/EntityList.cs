using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class EntityList : ScheduleHomePage
    {
        public static WebItem SearchInput =>
            new WebItem("//input[@id='search-input']", "Строка поиска");

        public static WebItem SearchButton =>
            new WebItem("//a[@id='search-button']", "Кнопка поиска");

        public static WebItem AddButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления");

        public void SearchEntity(string searchText)
        {
            SearchInput.SendKeys(searchText);
            SearchButton.Click();
        }
    }
}
