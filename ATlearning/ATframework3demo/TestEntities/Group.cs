using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.CreateForms;
using ATframework3demo.PageObjects.EditForms;

namespace ATframework3demo.TestEntities
{
    public class Group
    {
        public Group()
        {
            title = "Group" + DateTime.Now.Ticks;
        }

        public string title { get; set; }

        public List<Subject> subjects { get; set; }

        public GroupCreateForm Create(ScheduleHomePage homePage)
        {
            return homePage
                    .LeftMenu.OpenAdminPanel()
                    .OpenGroupList()
                    .OpenCreateGroupForm()
                    .AddGroup(this);
        }

        public GroupEditForm AddSubject(ScheduleHomePage homePage, Subject subject)
        {
            return homePage
                    .LeftMenu.OpenAdminPanel()
                    .OpenGroupList()
                    .OpenEditGroupForm(this)
                    .AddSubject(subject)
                    .SaveChanges();
        }
    }
}
