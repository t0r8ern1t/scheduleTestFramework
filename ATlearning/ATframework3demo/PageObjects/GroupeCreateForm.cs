using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class GroupeCreateForm : ScheduleHomePage
    {
        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия группы");

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

        public GroupeCreateForm AddGroupe(Groupe groupe)
        {
            TitleField.SendKeys(groupe.title);
            SubmitButton.Click();
            return this;
        }
    }
}
