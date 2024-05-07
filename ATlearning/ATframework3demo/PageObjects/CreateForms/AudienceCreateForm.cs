using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class AudienceCreateForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem TitleField =>
            new WebItem("//input[@name='NUMBER']", "Поле ввода названия аудитории");

        public static WebItem SubmitButton =>
            new WebItem("//button[@type='submit']", "Кнопка сохранения");

        public static WebItem TypeSelector =>
            new WebItem("//select[@name='TYPE']", "Селектор типа аудитории");

        public AudienceCreateForm SelectType(string typeName)
        {
            TypeSelector.Click();
            new WebItem($"//option[text()='{typeName}']", $"Опция выбора с текстом {typeName}")
                .Click();
            return this;
        }

        public AudienceCreateForm AddAudience(Audience audience)
        {
            TitleField.SendKeys(audience.title);
            SelectType(audience.type.title);
            SubmitButton.Click();
            return this;
        }
    }
}
