using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
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

        public GroupCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenGroupList()
                    .OpenCreateGroupForm()
                    .AddGroup(this);
        }

        public GroupEditForm AddSubject(AdminPanel adminPanel, Subject subject)
        {
            return adminPanel
                    .OpenGroupList()
                    .OpenEditGroupForm(this)
                    .AddSubject(subject)
                    .SaveChanges();
        }
    }
}
