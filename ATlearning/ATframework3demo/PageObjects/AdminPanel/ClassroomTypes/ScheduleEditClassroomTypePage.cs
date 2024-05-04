using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.ClassroomTypes
{
    public class ScheduleEditClassroomTypePage : ScheduleBaseEditPage
    {
        public ScheduleClassroomTypesPage DeleteClassroomType()
        {
            DeleteObject();
            return new ScheduleClassroomTypesPage();
        }

        public ScheduleClassroomTypesPage EditClassroomType(ScheduleClassroomType editedClassroomType)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(editedClassroomType.Title);
            SaveChanges();
            return new ScheduleClassroomTypesPage();
        }
    }
}
