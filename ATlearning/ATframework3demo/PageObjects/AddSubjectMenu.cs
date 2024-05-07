using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class AddSubjectMenu
    {
        private int addSubjectCounter = -1;

        public static WebItem AddSubjectButton =>
            new WebItem("//button[@id='addSubject']", "Кнопка добавления предмета");

        public static WebItem SubjectSelector(int addSubjectCounter) =>
            new WebItem($"//select[@name='add_subject_{addSubjectCounter}']", "Селектор предмета");

        public void AddSubjects(List<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                AddSubjectButton.Click();
                addSubjectCounter++;
                SubjectSelector(addSubjectCounter).SelectListItemByText(subject.title);
            }
        }
    }
}
