using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.ClassroomTypes
{
    public class ScheduleCreateClassroomTypePage
    {
        public ScheduleClassroomTypesPage FillFields(ScheduleClassroomType type)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(type.Title);

            new WebItem("//button[@type='submit']", "Кнопка Добавить").Click();

            new WebItem("//a[@id='back-button']", "Кнопка Назад").Click();
            return new ScheduleClassroomTypesPage();
        }
    }
}
