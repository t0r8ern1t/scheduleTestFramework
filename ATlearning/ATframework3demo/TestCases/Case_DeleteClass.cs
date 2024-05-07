using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;
using ATframework3demo.TestEntities.Users;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteClass : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление пары", homePage => DeleteClass(homePage)));
            return caseCollection;
        }

        public void DeleteClass(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType(id);
            ScheduleClassroom classroom = new ScheduleClassroom(type);
            ScheduleSubject subject = new ScheduleSubject(id, type);
            ScheduleGroup group = new ScheduleGroup(id, new List<ScheduleSubject> { subject });
            ScheduleTeacher teacher = new ScheduleTeacher(id, new List<ScheduleSubject> { subject });
            ScheduleClass myclass = new ScheduleClass(subject, classroom, group, teacher, ScheduleClass.WeekDay.Monday, 1);

            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            NotCase_CreateObjects
                // создаем пару
                .CreateClass(myclass, adminPanel)
                // удаляем пару
                .DeleteClass(myclass)
                // проверяем, пропала ли она из расписания
                .IsClassPresent(myclass, false);

            return;
        }
    }
}
