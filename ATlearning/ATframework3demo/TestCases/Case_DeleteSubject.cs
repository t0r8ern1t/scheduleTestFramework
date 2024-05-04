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
            ScheduleSubject subject = new ScheduleSubject();
            ScheduleSubject editedSubject = new ScheduleSubject();
            homePage
                .OpenAdminPanel()
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
