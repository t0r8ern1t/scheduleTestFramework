using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.ClassroomTypes
{
    public class ScheduleEditClassroomTypePage : ScheduleBaseEditPage
    {
        private WebItem titleField => new WebItem("//input[@name='TITLE']", "Поле ввода Название");

        public ScheduleClassroomTypesPage DeleteClassroomType()
        {
            DeleteObject();
            return new ScheduleClassroomTypesPage();
        }

        public ScheduleClassroomTypesPage EditClassroomType(ScheduleClassroomType editedClassroomType)
        {
            titleField.SendKeys(editedClassroomType.Title);
            Save();
            return new ScheduleClassroomTypesPage();
        }
    }
}
