using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleCreateSubjectPage
    {
        public ScheduleSubjectsPage FillFields(ScheduleSubject subject)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(subject.Title);
            new WebItem("//select[@name='TYPE']", "Выпадающий список ролей").SelectListItemByText(subject.GetTypeName());

            new WebItem("//button[@type='submit']", "Кнопка Добавить").Click();

            new WebItem("//a[@href='/admin/#subject']", "Кнопка Назад").Click();
            return new ScheduleSubjectsPage();
        }
    }
}
