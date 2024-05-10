using ATframework3demo.PageObjects.AdminPanel.Groups;
using ATframework3demo.PageObjects.AdminPanel;

namespace ATframework3demo.TestEntities.Users
{
    public class ScheduleStudent : ScheduleUser
    {
        public ScheduleGroup Group { get; set; }

        public ScheduleStudent(string id, ScheduleGroup group) : base(UserRole.Student, id) 
        { 
            Group = group;
        }
        public ScheduleAdminPanel CheckGroupForStudent(ScheduleAdminPanel adminPanel)
        {
            ScheduleGroupsPage groupsList = adminPanel.OpenGroupsList();
            if (!groupsList.FindGroup(this.Group))
            {
                groupsList.Return();
                this.Group.CreateGroup(adminPanel);
            }
            return groupsList.Return();
        }
    }
}
