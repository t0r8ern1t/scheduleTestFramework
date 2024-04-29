using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class GroupeList : ScheduleHomePage
    {
        public static WebItem AddGroupeButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления группы");

        public GroupeCreateForm OpenCreateGroupeForm()
        {
            AddGroupeButton.Click();
            return new GroupeCreateForm();
        }

        public GroupeEditForm OpenEditGroupeForm(Groupe groupe)
        {
            new WebItem($"//div[contains(text(), '{groupe.title}']", $"Кнопка группы {groupe.title}");
            return new GroupeEditForm();
        }
    }
}
