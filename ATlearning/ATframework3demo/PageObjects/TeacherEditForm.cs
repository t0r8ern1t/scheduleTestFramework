using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class TeacherEditForm : UserEditForm
    {
        private int addSubjectCounter = -1;

        public static WebItem AddSubjectButton =>
            new WebItem("//button[@id='addSubject']", "Кнопка добавления предмета");

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

        public TeacherEditForm SelectSubject(string subjectName, string selectorXpath)
        {
            new WebItem($"{selectorXpath}//child::option[contains(text(),'{subjectName}')]"
                , $"Опция выбора у селектора {selectorXpath}, с текстом {subjectName}")
                .Click();
            return this;
        }

        public TeacherEditForm AddSubject(Subject subject)
        {
            AddSubjectButton.Click();
            addSubjectCounter++;
            string selectorXpath = $"//select[@name='add_subject_{addSubjectCounter}']";
            new WebItem(selectorXpath, "Селектор предмета")
                .Click();
            SelectSubject(subject.title, selectorXpath);
            return this;
        }

        public TeacherEditForm SaveChanges()
        {
            addSubjectCounter = -1;
            SubmitButton.Click();
            return this;
        }
    }
}
