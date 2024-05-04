using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Subjects
{
    public class ScheduleEditSubjectPage : ScheduleBaseEditPage
    {
        public ScheduleSubjectsPage DeleteSubject()
        {
            DeleteObject();
            return new ScheduleSubjectsPage();
        }

        public ScheduleSubjectsPage EditSubject(ScheduleSubject editedSubject)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(editedSubject.Title);
            new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий").SelectListItemByText(editedSubject.Type.Title);
            SaveChanges();
            return new ScheduleSubjectsPage();
        }
    }
}
