using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.EditForms
{
    public class TeacherEditForm : UserEditForm
    {
        private AddSubjectMenu AddSubjectMenu => new AddSubjectMenu();

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

        public TeacherEditForm AddSubjects(List<Subject> subjects)
        {
            AddSubjectMenu.AddSubjects(subjects);
            SubmitButton.Click();
            return this;
        }
    }
}
