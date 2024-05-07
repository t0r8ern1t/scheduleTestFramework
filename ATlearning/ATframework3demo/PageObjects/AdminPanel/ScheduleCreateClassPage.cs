using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleCreateClassPage
    {
        public ScheduleHomePage FillFields(ScheduleClass myclass)
        {
            new WebItem("//select[@id='subject-select']", "Выпадающий список предметов в форме добавления пары")
                .SelectListItemByText(myclass.Subject.Title);
            new WebItem("//select[@id='audience-select']", "Выпадающий список аудиторий в форме добавления пары")
                .SelectListItemByText(myclass.Classroom.Title);
            new WebItem("//select[@id='group-select']", "Выпадающий список групп в форме добавления пары")
                .SelectListItemByText(myclass.Group.Title);
            new WebItem("//select[@id='teacher-select']", "Выпадающий список преподавателей в форме добавления пары")
                .SelectListItemByText(myclass.Teacher.FirstName + " " + myclass.Teacher.LastName);
            new WebItem("//button[@class='button is-success']", "Кнопка Сохранить").Click();
            return new ScheduleHomePage();
        }
    }
}
