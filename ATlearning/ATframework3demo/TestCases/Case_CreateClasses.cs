using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_CreateClasses : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание пары в расписании", homePage => CreateClass(homePage)));
            return caseCollection;
        }

        public void CreateClass(ScheduleHomePage homePage)
        {

        }

        public void CreateSubject(ScheduleHomePage homePage, Subject subject)
        {
            homePage
                .OpenAdminPanel()
                .OpenSubjectList()
                .OpenSubjectCreateForm()
                .AddSubject(subject);
        }

        public void CreateAudience(ScheduleHomePage homePage, Audience audience)
        {
            homePage
                .OpenAdminPanel()
                .OpenAudienceList()
                .OpenCreateAudienceForm()
                .AddAudience(audience);
        }

        public void CreateGroupe(ScheduleHomePage homePage, Groupe groupe)
        {
            homePage
                .OpenAdminPanel()
                .OpenGroupeList()
                .OpenCreateGroupeForm()
                .AddGroupe(groupe);
        }

        public void CreateTeacher(ScheduleHomePage homePage, Teacher teacher)
        {
            homePage
                .OpenAdminPanel()
                .OpenUserList()
                .OpenCreateUserForm()
                .FillUserData(teacher)
                .AddUser();
        }

        public void AddSubjectToGroupe(ScheduleHomePage homePage, Subject subject, Groupe groupe)
        {
            homePage
                .OpenAdminPanel()
                .OpenGroupeList()
                .OpenEditGroupeForm(groupe)
                .AddSubject(subject);
        }

        public void AddSubjectToTeacher(ScheduleHomePage homePage, Subject subject, Teacher teacher)
        {

        }
    }
}
