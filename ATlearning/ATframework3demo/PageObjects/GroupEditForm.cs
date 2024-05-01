using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class GroupEditForm : ScheduleHomePage
    {
        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия группы");

        public static WebItem AddSubjectButton =>
            new WebItem("//button[@id='addSubject']", "Кнопка добавления предмета");

        public static WebItem SubmitButton =>
            new WebItem("//button[contains(text(), 'Сохранить')]", "Кнопка сохранения");

        private int addSubjectCounter = -1;

        public GroupEditForm SelectSubject(string subjectName, string selectorXpath)
        {
            new WebItem($"{selectorXpath}//child::option[contains(text(),'{subjectName}')]"
                , $"Опция выбора у селектора {selectorXpath}, с текстом {subjectName}")
                .Click();
            return this;
        }

        public GroupEditForm AddSubject(Subject subject)
        {
            AddSubjectButton.Click();
            addSubjectCounter++;
            string selectorXpath = $"//select[@name='add_subject_{addSubjectCounter}']";
            new WebItem(selectorXpath, "Селектор предмета")
                .Click();
            SelectSubject(subject.title, selectorXpath);
            return this;
        }

        public GroupEditForm SaveChanges()
        {
            addSubjectCounter = -1;
            SubmitButton.Click();
            return this;
        }
    }
}
