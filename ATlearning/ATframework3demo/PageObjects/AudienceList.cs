using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class AudienceList : ScheduleHomePage
    {
        public static WebItem AddAudienceButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления аудитории");

        public AudienceCreateForm OpenCreateAudienceForm()
        {
            AddAudienceButton.Click();
            return new AudienceCreateForm();
        }
    }
}
