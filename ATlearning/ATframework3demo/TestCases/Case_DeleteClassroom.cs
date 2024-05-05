using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteClassrom : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменение и удаление аудитории", homePage => DeleteClassroom(homePage)));
            return caseCollection;
        }

        public void DeleteClassroom(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType("Type" + id);
            ScheduleClassroom classroom = new ScheduleClassroom(("Room" + id).Substring(0, 9), type);
            ScheduleClassroom editedClassroom = new ScheduleClassroom(("Room" + id).Substring(0, 8), type);

            NotCase_CreateObjects sys = new NotCase_CreateObjects();
            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            sys
                // создаем предмет
                .CreateClassroom(classroom, adminPanel)
                // открываем список предметов
                .OpenClassroomsList()
                // открываем фрому редактирования
                .OpenEditForm(classroom)
                // редактируем
                .EditClassroom(editedClassroom)
                // проверяем, изменился ли предмет
                .IsClassroomPresent(editedClassroom, true)
                // открываем форму редактирования
                .OpenEditForm(editedClassroom)
                // удаляем
                .DeleteClassroom()
                // проверяем, удален ли предмет
                .IsClassroomPresent(editedClassroom, false);
            return;
        }
    }
}
