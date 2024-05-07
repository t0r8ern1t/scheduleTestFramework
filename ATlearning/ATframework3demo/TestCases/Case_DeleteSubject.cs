using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_DeleteSubject : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменение и удаление предмета", homePage => DeleteSubject(homePage)));
            return caseCollection;
        }

        public void DeleteSubject(ScheduleHomePage homePage)
        {
            string id = DateTime.Now.Ticks.ToString();
            ScheduleClassroomType type = new ScheduleClassroomType(id);
            ScheduleSubject subject = new ScheduleSubject(id, type);
            id = DateTime.Now.Ticks.ToString();
            ScheduleSubject editedSubject = new ScheduleSubject(id, type);

            ScheduleAdminPanel adminPanel = homePage.OpenAdminPanel();

            NotCase_CreateObjects
                // создаем предмет
                .CreateSubject(subject, adminPanel)
                // открываем список предметов
                .OpenSubjectsList()
                // открываем фрому редактирования
                .OpenEditForm(subject)
                // редактируем
                .EditSubject(editedSubject)
                // проверяем, изменился ли предмет
                .IsSubjectPresent(editedSubject, true)
                // открываем форму редактирования
                .OpenEditForm(editedSubject)
                // удаляем
                .DeleteSubject()
                // проверяем, удален ли предмет
                .IsSubjectPresent(editedSubject, false);
            return;
        }
    }
}
