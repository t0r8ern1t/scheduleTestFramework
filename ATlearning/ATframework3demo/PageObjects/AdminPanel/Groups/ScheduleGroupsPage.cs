using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Groups
{
    public class ScheduleGroupsPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateGroupPage CreateGroup()
        {
            CreateObject();
            return new ScheduleCreateGroupPage();
        }

        public ScheduleGroupsPage IsGroupPresent(ScheduleGroup group, bool shouldBePresent)
        {
            IsObjectPresent(group.Title, shouldBePresent);
            return this;
        }

        public ScheduleEditGroupPage OpenEditForm(ScheduleGroup group)
        {
            OpenBaseEditForm(group.Title);
            return new ScheduleEditGroupPage();
        }
    }
}
