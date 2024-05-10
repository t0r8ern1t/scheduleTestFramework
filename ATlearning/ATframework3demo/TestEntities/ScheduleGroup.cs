using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.PageObjects.AdminPanel;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestEntities
{
    public class ScheduleGroup
    {
        public string Title { get; set; }
        public List<ScheduleSubject> Subjects { get; set; }

        public ScheduleGroup(string id, List<ScheduleSubject> subjects)
        {
            Title = "Group" + id;
            Subjects = subjects;
        }

        public ScheduleAdminPanel CreateGroup(ScheduleAdminPanel adminPanel, bool isCheckNeeded = true)
        {
            Log.Info("Создание группы");
            // проверяем существуют ли предметы, указанные в параметрах группы
            // если нет - создаем
            if (isCheckNeeded)
            {
                ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
                foreach (var subject in this.Subjects)
                {
                    if (!subjectsList.FindSubject(subject))
                    {
                        adminPanel = subject.CreateSubject(subjectsList.Return());
                    }
                }
                adminPanel = subjectsList.Return();
            }

            adminPanel
                // открываем список групп
                .OpenGroupsList()
                // нажимаем создать
                .CreateGroup()
                // заполняем форму
                .FillFields(this)
                // проверяем, есть ли группа в списке
                .IsGroupPresent(this, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }
    }
}
