using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities.Users;
using ATframework3demo.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;

namespace ATframework3demo.TestCases
{
    public class Case_Edit_Teacher : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление новых предметов пользователю-преподавателю", homePage => EditTeacher(homePage)));
            return caseCollection;
        }

        public void EditTeacher(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType(id);
            ScheduleSubject subject = new ScheduleSubject(id, type);
            ScheduleTeacher teacher = new ScheduleTeacher(id, new List<ScheduleSubject> { subject });

            ScheduleSubject newSubject = new ScheduleSubject(new Random().Next(100).ToString(), type);
            ScheduleTeacher newTeacher = new ScheduleTeacher(id, new List<ScheduleSubject> { newSubject });
            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            NotCase_CreateObjects
                .CreateSubject(newSubject, adminPanel);

            NotCase_CreateObjects
                .CreateUser(teacher, adminPanel)
                .OpenUsersList()
                .OpenEditForm(teacher)
                .EditUser(newTeacher)
                .IsUserPresent(newTeacher, true)
                .OpenEditForm(newTeacher)
                .AreSubjectsCorrect(newTeacher);
        }
    }
}
