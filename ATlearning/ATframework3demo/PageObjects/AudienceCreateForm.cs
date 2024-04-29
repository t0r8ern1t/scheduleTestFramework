using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class AudienceCreateForm : ScheduleHomePage
    {
        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия аудитории");

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

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
            SelectType(audience.GetTypeName());
            SubmitButton.Click();
            return this;
        }
    }
}
