using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class GroupList : EntityList
    {
        public GroupCreateForm OpenCreateGroupForm()
        {
            AddButton.Click();
            return new GroupCreateForm();
        }

        public GroupEditForm OpenEditGroupForm(Group group)
        {
            SearchEntity(group.title);
            new WebItem($"//div[contains(text(), '{group.title}')]", $"Кнопка группы {group.title}")
                .Click();
            return new GroupEditForm();
        }
    }
}
