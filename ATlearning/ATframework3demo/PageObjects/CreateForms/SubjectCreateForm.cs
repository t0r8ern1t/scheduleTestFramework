using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class SubjectCreateForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия предмета");

        public static WebItem SubmitButton =>
            new WebItem("//button[@type='submit']", "Кнопка сохранения");

        public static WebItem TypeSelector =>
            new WebItem("//select[@name='TYPE']", "Селектор типа аудитории");

        public SubjectCreateForm SelectType(string typeName)
        {
            TypeSelector.Click();
            new WebItem($"//option[text()='{typeName}']", $"Опция выбора с текстом {typeName}")
                .Click();
            return this;
        }

        public SubjectCreateForm AddSubject(Subject subject)
        {
            TitleField.SendKeys(subject.title);
            SelectType(subject.audienceType.title);
            SubmitButton.Click();
            return this;
        }
    }
}
