using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Groups
{
    public class ScheduleCreateGroupPage
    {
        public ScheduleGroupsPage FillFields(ScheduleGroup group)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(group.Title);
            int iter = 0;

            foreach (var subject in group.Subjects) 
            {
                new WebItem("//button[@id='addSubject']", "Кнопка Добавить Предметы").Click();
                new WebItem($"//select[@name='add_subject_{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }

            new WebItem("//button[@type='submit']", "Кнопка Добавить").Click();

            new WebItem("//a[@id='back-button']", "Кнопка Назад").Click();
            return new ScheduleGroupsPage();
        }
    }
}
