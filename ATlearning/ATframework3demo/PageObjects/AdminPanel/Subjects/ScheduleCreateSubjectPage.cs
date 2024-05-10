using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Subjects
{
    public class ScheduleCreateSubjectPage : ScheduleBaseCreatePage
    {
        private WebItem titleField => new WebItem("//input[@name='TITLE']", "Поле ввода Название");
        private WebItem typesList => new WebItem("//select[@name='TYPE']", "Выпадающий список типов аудиторий");
        public ScheduleSubjectsPage FillFields(ScheduleSubject subject)
        {
            titleField.SendKeys(subject.Title);
            typesList.SelectListItemByText(subject.Type.Title);
            Save();

            return new ScheduleSubjectsPage();
        }
    }
}
