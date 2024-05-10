using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public abstract class ScheduleBaseEditPage
    {
        protected WebItem deleteButton => new WebItem("//button[@class='button ml-2 is-danger']", "Кнопка Удалить");
        protected WebItem confirmDeleteButton => new WebItem("//button[@id='delete-button']", "Подтверждение удаления");
        protected WebItem saveButton => new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка Сохранить");
        protected WebItem backButton => new WebItem("//a[@id='back-button']", "Кнопка Назад");

        public void DeleteObject()
        {
            deleteButton.Click();
            confirmDeleteButton.Click();
        }

        public void Save()
        {
            saveButton.Click();
            backButton.Click();
        }
    }
}
