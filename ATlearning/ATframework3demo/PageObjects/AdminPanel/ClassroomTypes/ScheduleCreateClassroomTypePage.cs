using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.ClassroomTypes
{
    public class ScheduleCreateClassroomTypePage : ScheduleBaseCreatePage
    {
        private WebItem titleField => new WebItem("//input[@name='TITLE']", "Поле ввода Название");
        public ScheduleClassroomTypesPage FillFields(ScheduleClassroomType type)
        {
            titleField.SendKeys(type.Title);
            Save();

            return new ScheduleClassroomTypesPage();
        }
    }
}
