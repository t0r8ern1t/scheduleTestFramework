using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Classrooms
{
    public class ScheduleCreateClassroomPage : ScheduleBaseCreatePage
    {
        private WebItem numberField => new WebItem("//input[@name='NUMBER']", "Поле ввода Название");
        private WebItem roomsList => new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий");
        
        public ScheduleClassroomsPage FillFields(ScheduleClassroom classroom)
        {
            numberField.SendKeys(classroom.Title);
            roomsList.SelectListItemByText(classroom.Type.Title);
            Save();
            return new ScheduleClassroomsPage();
        }
    }
}
