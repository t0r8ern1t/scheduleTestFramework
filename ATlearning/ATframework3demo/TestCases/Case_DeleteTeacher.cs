using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;
using ATframework3demo.TestEntities.Users;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteTeacher : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление пользователя-преподавателя, которому назначена пара", homePage => DeleteTeacher(homePage)));
            return caseCollection;
        }

        public void DeleteTeacher(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType(id);
            ScheduleClassroom classroom = new ScheduleClassroom(type);
            ScheduleSubject subject = new ScheduleSubject(id, type);
            ScheduleGroup group = new ScheduleGroup(id, new List<ScheduleSubject> { subject });
            ScheduleTeacher teacher = new ScheduleTeacher(id, new List<ScheduleSubject> { subject });
            ScheduleClass myclass = new ScheduleClass(subject, classroom, group, teacher, ScheduleClass.WeekDay.Monday, 1);

            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            myclass
                .CreateClass(adminPanel)
                .OpenAdminPanel()
                .OpenUsersList()
                .OpenEditForm(myclass.Teacher)
                .DeleteUser()
                .IsUserPresent(myclass.Teacher, false)
                .Return()
                .OpenHomePage()
                .ChooseGroup(myclass.Group)
                .IsClassPresent(myclass, false);
        }
    }
}
