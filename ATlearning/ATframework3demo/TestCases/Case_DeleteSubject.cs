using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteSubject : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление предмета", homePage => DeleteUser(homePage)));
            return caseCollection;
        }



        public void DeleteUser(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType("Type" + id);
            ScheduleSubject subject = new ScheduleSubject("Subject" + id, type);
            id = DateTime.Now.Ticks.ToString();
            ScheduleSubject editedSubject = new ScheduleSubject("Subject" + id, type);
            homePage
                .OpenAdminPanel()
                .OpenClassroomTypesList()
                .CreateClassroomType()
                .FillFields(type)
                .IsClassroomTypePresent(type, true)
                .Return()
                .OpenSubjectsList()
                .CreateSubject()
                .FillFields(subject)
                .IsSubjectPresent(subject, true)
                .OpenEditForm(subject)
                .EditSubject(editedSubject)
                .IsSubjectPresent(editedSubject, true)
                .OpenEditForm(editedSubject)
                .DeleteSubject()
                .IsSubjectPresent(editedSubject, false);
            return;
        }
    }
}
