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
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(editedClassroom.Title);
            new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий").SelectListItemByText(editedClassroom.Type.Title);
            SaveChanges();
            return new ScheduleClassroomsPage();
        }
    }
}
