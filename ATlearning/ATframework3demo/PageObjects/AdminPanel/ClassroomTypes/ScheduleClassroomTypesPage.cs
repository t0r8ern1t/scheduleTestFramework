using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.Users;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.ClassroomTypes
{
    public class ScheduleClassroomTypesPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateClassroomTypePage CreateClassroomType()
        {
            CreateObject();
            return new ScheduleCreateClassroomTypePage();
        }

        public ScheduleClassroomTypesPage IsClassroomTypePresent(ScheduleClassroomType type, bool shouldBePresent)
        {
            IsObjectPresent(type.Title, shouldBePresent);
            return this;
        }

        public ScheduleEditClassroomTypePage OpenEditForm(ScheduleClassroomType type)
        {
            OpenBaseEditForm(type.Title);
            return new ScheduleEditClassroomTypePage();
        }
    }
}
