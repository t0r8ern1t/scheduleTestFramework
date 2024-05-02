using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_CreateEntities : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание пары в расписании, в лекционной аудитории", homePage => CreateLesson(homePage, AudienceType.Lecture)));
            caseCollection.Add(new TestCase("Создание нового преподавателя", homePage => CreateTeacher(homePage, new Teacher())));
            return caseCollection;
        }

        public void CreateTeacher(ScheduleHomePage homePage, Teacher teacher)
        {
            homePage = teacher.Create(homePage).OpenSchedule();

            bool isLoginedInCreatedTeacher = homePage
                .Logout()
                .OpenLoginPage()
                .Login(teacher)
                .isLogined();

            if (!isLoginedInCreatedTeacher)
            {
                Log.Error("Вход в созданный аккаунт не выполнен");
            }
        }

            public void CreateLesson(ScheduleHomePage homePage, AudienceType audienceType)
        {
            DayOfWeek lessonDayOfWeek = DayOfWeek.Monday;
            int lessonNumber = 1;
            Group group = new Group();
            Teacher teacher = new Teacher();
            Subject subject = new Subject(audienceType);
            Audience audience = new Audience(audienceType);
            Lesson lesson = new Lesson(lessonDayOfWeek, lessonNumber, subject, audience, teacher, group);

            homePage = group.Create(homePage).OpenSchedule();

            homePage = subject.Create(homePage).OpenSchedule();

            homePage = audience.Create(homePage).OpenSchedule();

            homePage = teacher.Create(homePage).OpenSchedule();

            homePage = group.AddSubject(homePage, subject).OpenSchedule();

            homePage = teacher.AddTeachingSubject(homePage, subject).OpenSchedule();

            homePage
                .SelectGroup(group)
                .OpenAddLessonForm(lesson)
                .FillClassData(lesson)
                .SaveChanges();

            if (!homePage.isLessonRepresentInSchedule(lesson))
            {
                Log.Error($"Созданая пара, по предмету {subject.title} в аудитории {audience.title}, не отображается в окне пары: {lesson.GetNumberDayOfWeek()} день недели, {lessonNumber} номер пары");
            }
        }
    }
}
