using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;
using System.Xml.Linq;

namespace ATframework3demo.PageObjects.AdminPanel.Groups
{
    public class ScheduleEditGroupPage : ScheduleBaseEditPage
    {
        public ScheduleGroupsPage DeleteGroup()
        {
            DeleteObject();
            return new ScheduleGroupsPage();
        }

        public ScheduleGroupsPage EditGroup(ScheduleGroup group, ScheduleGroup editedGroup)
        {
            new WebItem("//input[@name='TITLE']", "Поле ввода Название").SendKeys(editedGroup.Title);

            for (int i = 1; i <= group.Subjects.Count; i++)
            {
                try
                {
                    new WebItem($"//button[@id='delete_subject_{i}']", "").Click();
                }
                catch 
                {
                    Log.Error($"Предмета {group.Subjects[i - 1].Title} нет в списке");
                }
            }

            int iter = 0;

            foreach (var subject in group.Subjects)
            {
                new WebItem("//button[@id'addSubject']", "Кнопка Добавить Предметы").Click();
                new WebItem($"//select[@name='add_subject_+{iter}']", "Выпадающий список предметов").SelectListItemByText(subject.Title);
                iter++;
            }

            Save();
            return new ScheduleGroupsPage();
        }
    }
}
