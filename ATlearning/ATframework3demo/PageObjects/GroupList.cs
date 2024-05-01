using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class GroupList : ScheduleHomePage
    {
        public static WebItem AddGroupButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления группы");

        public GroupCreateForm OpenCreateGroupForm()
        {
            AddGroupButton.Click();
            return new GroupCreateForm();
        }

        public GroupEditForm OpenEditGroupForm(Group group)
        {
            new WebItem($"//div[contains(text(), '{group.title}')]", $"Кнопка группы {group.title}")
                .Click();
            return new GroupEditForm();
        }
    }
}
