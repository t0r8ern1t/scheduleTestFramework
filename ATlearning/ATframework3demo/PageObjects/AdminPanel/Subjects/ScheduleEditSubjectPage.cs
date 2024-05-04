using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Subjects
{
    public class ScheduleEditSubjectPage
    {
        public ScheduleSubjectsPage DeleteSubject()
        {
            new WebItem("//button[@class='button ml-2 is-danger']", "Кнопка Удалить").Click();
            new WebItem("//button[@id='delete-button']", "Подтверждение удаления").Click();
            return new ScheduleSubjectsPage();
        }

        public ScheduleSubjectsPage EditSubject(ScheduleSubject editedSubject)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(editedSubject.Title);
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка Сохранить").Click();
            new WebItem("//a[@href='/admin/#subject']", "Кнопка Назад").Click();
            return new ScheduleSubjectsPage();
        }
    }
}
