using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public abstract class ScheduleBaseEditPage
    {
        public void DeleteObject()
        {
            new WebItem("//button[@class='button ml-2 is-danger']", "Кнопка Удалить").Click();
            new WebItem("//button[@id='delete-button']", "Подтверждение удаления").Click();
        }

        public void SaveChanges()
        {
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка Сохранить").Click();
            new WebItem("//a[@id='back-button']", "Кнопка Назад").Click();
        }
    }
}
