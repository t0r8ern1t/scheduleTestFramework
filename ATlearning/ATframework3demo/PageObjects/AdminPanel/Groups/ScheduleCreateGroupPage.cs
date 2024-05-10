using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Groups
{
    public class ScheduleCreateGroupPage : ScheduleBaseCreatePage
    {
        private WebItem titleField => new WebItem("//input[@name='TITLE']", "Поле ввода Название");
        private WebItem addSubjectButton => new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предметы");

        public ScheduleGroupsPage FillFields(ScheduleGroup group)
        {
            titleField.SendKeys(group.Title);
            int iter = 0;

            foreach (var subject in group.Subjects) 
            {
                addSubjectButton.Click();
                new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }

            Save();
            return new ScheduleGroupsPage();
        }
    }
}
