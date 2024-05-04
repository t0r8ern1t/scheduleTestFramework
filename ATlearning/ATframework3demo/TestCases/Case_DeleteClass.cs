using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;

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
            ScheduleClassroomType type = new ScheduleClassroomType("Type" + id);
            ScheduleClassroom classroom = new ScheduleClassroom(("Room" + id).Substring(0, 9), type);
            ScheduleSubject subject = new ScheduleSubject(("Subject" + id).Substring(0, 12), type);
            ScheduleGroup group = new ScheduleGroup("Group" + id, new List<ScheduleSubject> { subject });
            ScheduleUser teacher = new ScheduleUser();
            teacher.MakeTeacherUser(id, new List<ScheduleSubject> { subject });
            ScheduleClass myclass = new ScheduleClass(subject, classroom, group, teacher, ScheduleClass.WeekDay.Monday, 1);

            NotCase_CreateObjects sys = new NotCase_CreateObjects();
            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            sys
                .CreateClass(myclass, adminPanel)
                .DeleteClass(myclass)
                .IsClassPresent(myclass, false);

            return;
        }
    }
}
