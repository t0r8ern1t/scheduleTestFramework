using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Classrooms
{
    public class ScheduleEditClassroomPage : ScheduleBaseEditPage
    {
        private WebItem numberField => new WebItem("//input[@name='NUMBER']", "Поле ввода Название");
        private WebItem roomsList => new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий");

        public ScheduleClassroomsPage DeleteClassroom()
        {
            DeleteObject();
            return new ScheduleClassroomsPage();
        }

        public ScheduleClassroomsPage EditClassroom(ScheduleClassroom editedClassroom)
        {
            numberField.SendKeys(editedClassroom.Title);
            roomsList.SelectListItemByText(editedClassroom.Type.Title);
            Save();
            return new ScheduleClassroomsPage();
        }
    }
}
