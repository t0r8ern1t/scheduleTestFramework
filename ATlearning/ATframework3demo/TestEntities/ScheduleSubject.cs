using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel;
using System.Reflection;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestEntities
{
    public class ScheduleSubject
    {
        public string Title {  get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleSubject(string id, ScheduleClassroomType type)
        {
            Title = "Subject" + id;
            Type = type;
        }

        public ScheduleAdminPanel CreateSubject(ScheduleAdminPanel adminPanel, bool isCheckNeeded = true)
        {
            Log.Info("Создание предмета");
            // проверяем, существует ли нужный тип аудитории, если нет - создаем
            if (isCheckNeeded)
            {
                ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
                if (!classroomTypesList.FindClassroomType(this.Type))
                {
                    adminPanel = this.Type.CreateClassroomType(classroomTypesList.Return());
                }
                else
                {
                    adminPanel = classroomTypesList.Return();
                }
            }
            adminPanel
                // открываем список предметов
                .OpenSubjectsList()
                // нажимаем добавить
                .CreateSubject()
                // заполняем форму
                .FillFields(this)
                // проверяем, есть ли предмет в списке
                .IsSubjectPresent(this, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }

    }
}
