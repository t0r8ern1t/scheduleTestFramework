using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities.Users;

namespace ATframework3demo.TestEntities
{
    public class ScheduleClass
    {
        public ScheduleSubject Subject { get; set; }
        public ScheduleClassroom Classroom { get; set; }
        public ScheduleGroup Group { get; set; }
        public ScheduleTeacher Teacher { get; set; }

        public WeekDay Day { get; set; }
        public int Number { get; set; }

        public ScheduleClass(ScheduleSubject subject, ScheduleClassroom classroom, ScheduleGroup group, ScheduleTeacher teacher, WeekDay day, int number) 
        {
            Subject = subject;
            Classroom = classroom;
            Group = group;
            Teacher = teacher;
            Day = day;
            Number = number;
        }

        public ScheduleHomePage CreateClass(ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание пары");
            // создаем объекты всех параметров
            adminPanel = this.Subject.Type.CreateClassroomType(adminPanel);
            adminPanel = this.Subject.CreateSubject(adminPanel, false);
            adminPanel = this.Classroom.CreateClassroom(adminPanel, false);
            adminPanel = this.Group.CreateGroup(adminPanel, false);
            adminPanel = this.Teacher.CreateUser(adminPanel, false);

            adminPanel
                // открываем главную страницу
                .OpenHomePage()
                // выбираем нужную группу в дропдауне
                .ChooseGroup(this.Group)
                // нажимаем на плюсик в нужной ячейке
                .AddClass(this)
                // заполняем форму
                .FillFields(this)
                // проверяем, добавилась ли пара в ячейку
                .IsClassPresent(this, true);

            return new ScheduleHomePage();
        }

        public enum WeekDay
        {
            Monday = 1, 
            Tuesday = 2, 
            Wednesday = 3, 
            Thursday = 4, 
            Friday = 5, 
            Saturday = 6
        }
    }
}
