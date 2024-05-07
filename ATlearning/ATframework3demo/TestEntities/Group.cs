using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.CreateForms;
using ATframework3demo.PageObjects.EditForms;

namespace ATframework3demo.TestEntities
{
    public class Group
    {
        public Group(List<Subject> subjects)
        {
            title = "Group" + DateTime.Now.Ticks;
            this.subjects = subjects;
        }

        public string title { get; set; }

        public List<Subject> subjects { get; set; }

        public GroupCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenGroupList()
                    .OpenCreateGroupForm()
                    .AddGroup(this, subjects);
        }

        public GroupEditForm AddSubjects(AdminPanel adminPanel, List<Subject> subjects)
        {
            return adminPanel
                    .OpenGroupList()
                    .OpenEditGroupForm(this)
                    .AddSubjects(subjects);
        }
    }
}
