using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel.Classrooms
{
    public class ScheduleClassroomsPage : ScheduleBaseObjectsPage
    {
        public ScheduleCreateClassroomPage CreateClassroom()
        {
            CreateObject();
            return new ScheduleCreateClassroomPage();
        }

        public ScheduleClassroomsPage IsClassroomPresent(ScheduleClassroom classroom, bool shouldBePresent)
        {
            Log.Info($"Поиск аудитории {classroom.Title} в списке");
            IsObjectPresent(classroom.Title, shouldBePresent);
            return this;
        }

        public ScheduleEditClassroomPage OpenEditForm(ScheduleClassroom classroom)
        {
            OpenBaseEditForm(classroom.Title);
            return new ScheduleEditClassroomPage();
        }

        public bool FindClassroom(ScheduleClassroom classroom)
        {
            Log.Info($"Поиск аудитории {classroom.Title} в списке");
            return FindObject(classroom.Title);
        }
    }
}
