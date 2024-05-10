using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Subjects
{
    public class ScheduleEditSubjectPage : ScheduleBaseEditPage
    {
        private WebItem titleField => new WebItem("//input[@name='TITLE']", "Поле ввода Название");
        private WebItem typesList => new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий");

        public ScheduleSubjectsPage DeleteSubject()
        {
            DeleteObject();
            return new ScheduleSubjectsPage();
        }

        public ScheduleSubjectsPage EditSubject(ScheduleSubject editedSubject)
        {
            titleField.SendKeys(editedSubject.Title);
            typesList.SelectListItemByText(editedSubject.Type.Title);
            Save();
            return new ScheduleSubjectsPage();
        }
    }
}
