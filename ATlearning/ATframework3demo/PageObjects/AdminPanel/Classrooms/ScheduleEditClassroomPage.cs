using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Classrooms
{
    public class ScheduleEditClassroomPage : ScheduleBaseEditPage
    {
        public ScheduleClassroomsPage DeleteClassroom()
        {
            DeleteObject();
            return new ScheduleClassroomsPage();
        }

        public ScheduleClassroomsPage EditClassroom(ScheduleClassroom editedClassroom)
        {
            new WebItem("//input[@name='NUMBER']", "Поле ввода Название").SendKeys(editedClassroom.Title);
            new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий").SelectListItemByText(editedClassroom.Type.Title);
            Save();
            return new ScheduleClassroomsPage();
        }
    }
}
