using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public abstract class ScheduleBaseCreatePage
    {
        protected WebItem addButton => new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка Сохранить");
        protected WebItem backButton => new WebItem("//a[@id='back-button']", "Кнопка Назад");

        public void Save()
        {
            addButton.Click();
            backButton.Click();
        }
    }
}
