using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.PageObjects.AdminPanel;

namespace ATframework3demo.TestEntities
{
    public class ScheduleClassroomType
    {
        public string Title { get; set; }

        public ScheduleClassroomType(string id)
        { 
            Title = "Type" + id;
        }

        public ScheduleAdminPanel CreateClassroomType(ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание типа аудитории");
            adminPanel
                // открываем список типов аудиторий
                .OpenClassroomTypesList()
                // нажимаем добавить
                .CreateClassroomType()
                // заполняем поля, сохраняем
                .FillFields(this)
                // проверяем, есть ли тип в списке
                .IsClassroomTypePresent(this, true)
                // возвращяемся на админ. панель
                .Return();
            return adminPanel;
        }
    }
}
