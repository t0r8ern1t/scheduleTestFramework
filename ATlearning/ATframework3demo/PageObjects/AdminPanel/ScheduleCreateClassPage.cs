using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleCreateClassPage
    {
        private WebItem subjectSelect => new WebItem("//select[@id='subject-select']", "Выпадающий список предметов в форме добавления пары");
        private WebItem roomSelect => new WebItem("//select[@id='audience-select']", "Выпадающий список аудиторий в форме добавления пары");
        private WebItem groupSelect => new WebItem("//select[@id='group-select']", "Выпадающий список групп в форме добавления пары");
        private WebItem teacherSelect => new WebItem("//select[@id='teacher-select']", "Выпадающий список преподавателей в форме добавления пары");
        private WebItem saveButton => new WebItem("//button[@class='button is-success']", "Кнопка Сохранить");

        public ScheduleHomePage FillFields(ScheduleClass myclass)
        {
            subjectSelect.SelectListItemByText(myclass.Subject.Title);
            roomSelect.SelectListItemByText(myclass.Classroom.Title);
            groupSelect.SelectListItemByText(myclass.Group.Title);
            teacherSelect.SelectListItemByText(myclass.Teacher.FirstName + " " + myclass.Teacher.LastName);
            saveButton.Click();

            return new ScheduleHomePage();
        }
    }
}
