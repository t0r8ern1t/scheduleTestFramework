using atFrameWork2.BaseFramework.LogTools;
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
            Log.Info($"Поиск группы {group.Title} в списке");
            IsObjectPresent(group.Title, shouldBePresent);
            return this;
        }

        public ScheduleEditGroupPage OpenEditForm(ScheduleGroup group)
        {
            OpenBaseEditForm(group.Title);
            return new ScheduleEditGroupPage();
        }

        public bool FindGroup (ScheduleGroup group)
        {
            Log.Info($"Поиск группы {group.Title} в списке");
            return FindObject(group.Title);
        }
    }
}
