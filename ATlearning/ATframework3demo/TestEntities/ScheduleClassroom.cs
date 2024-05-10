using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroom
    {
        public string Title { get; set; }
        public ScheduleClassroomType Type { get; set; }

        public ScheduleClassroom(ScheduleClassroomType type)
        {
            Title = "Room" + new Random().Next(100000);
            Type = type;
        }

        public ScheduleAdminPanel CreateClassroom(ScheduleAdminPanel adminPanel, bool isCheckNeeded = true)
        {
            Log.Info("Создание аудитории");
            // проверяем существует ли нужный тип, если нет - создаем
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
                // открываем список аудиторий
                .OpenClassroomsList()
                // нажимаем добавить
                .CreateClassroom()
                // заполняем форму
                .FillFields(this)
                // проверяем есть ли тип в списке
                .IsClassroomPresent(this, true)
                // возвращаемся на админ панель
                .Return();
            return adminPanel;
        }
    }
}
