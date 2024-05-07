using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class AudienceTypeCreateForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия предмета");

        public static WebItem SubmitButton =>
            new WebItem("//button[@type='submit']", "Кнопка сохранения");

        public AudienceTypeCreateForm AddAudienceType(AudienceType audienceType)
        {
            TitleField.SendKeys(audienceType.title);
            SubmitButton.Click();
            return this;
        }
    }
}
