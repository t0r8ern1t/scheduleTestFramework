using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.EditForms
{
    public class GroupEditForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        private AddSubjectMenu AddSubjectMenu => new AddSubjectMenu();

        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия группы");

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

        public GroupEditForm AddSubjects(List<Subject> subjects)
        {
            AddSubjectMenu.AddSubjects(subjects);
            SubmitButton.Click();
            return this;
        }
    }
}
