using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Classrooms
{
    public class ScheduleCreateClassroomPage
    {
        public ScheduleClassroomsPage FillFields(ScheduleClassroom classroom)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(classroom.Title);
            new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий").SelectListItemByText(classroom.Type.Title);

            new WebItem("//button[@type='submit']", "Кнопка Добавить").Click();

            new WebItem("//a[@id='back-button']", "Кнопка Назад").Click();
            return new ScheduleClassroomsPage();
        }
    }
}
