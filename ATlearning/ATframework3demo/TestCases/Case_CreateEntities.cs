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
            caseCollection.Add(new TestCase("Создание пары в расписании, в лекционной аудитории", homePage => CreateLesson(homePage)));
            caseCollection.Add(new TestCase("Создание нового преподавателя", homePage => CreateTeacher(homePage, new Teacher())));
            caseCollection.Add(new TestCase("Создание нового предмета", homePage => CreateSubject(homePage, new Subject(new AudienceType()))));
            caseCollection.Add(new TestCase("Создание новой группы", homePage => CreateGroup(homePage, new Group())));
            caseCollection.Add(new TestCase("Создание новой аудитории", homePage => CreateAudience(homePage, new Audience(new AudienceType()))));
            return caseCollection;
        }

        public void CreateAudience(ScheduleHomePage homePage, Audience audience)
        {
            homePage = audience.type
                .Create(homePage)
                .LeftMenu.OpenSchedule();

            var isAudienceRepresentedInAudienceList = audience.Create(homePage)
                .LeftMenu.OpenAdminPanel()
                .OpenAudienceList()
                .IsEntityRepresented(audience.title);

            if (!isAudienceRepresentedInAudienceList)
            {
                Log.Error($"Аудитория с названием {audience.title}, не отображается в списке аудиторий");
            }
        }

        public void CreateSubject(ScheduleHomePage homePage, Subject subject)
        {
            homePage = subject.audienceType
                .Create(homePage)
                .LeftMenu.OpenSchedule();
            var isSubjectRepresentedInSubjectList = subject.Create(homePage)
                .LeftMenu.OpenAdminPanel()
                .OpenSubjectList()
                .IsEntityRepresented(subject.title);

            if (!isSubjectRepresentedInSubjectList)
            {
                Log.Error($"Предмет с названием {subject.title}, не отображается в списке предметов");
            }
        }

        public void CreateGroup(ScheduleHomePage homePage, Group group)
        {
            var isGroupRepresentedInGrouptList = group.Create(homePage)
                .LeftMenu.OpenAdminPanel()
                .OpenGroupList()
                .IsEntityRepresented(group.title);

            if (!isGroupRepresentedInGrouptList)
            {
                Log.Error($"Группа с названием {group.title}, не отображается в списке групп");
            }
        }

        public void CreateTeacher(ScheduleHomePage homePage, Teacher teacher)
        {
            bool isLoginedInCreatedTeacher = teacher.Create(homePage)
                .LeftMenu.Logout()
                .LeftMenu.OpenLoginPage()
                .Login(teacher)
                .LeftMenu.isLogined();

            if (!isLoginedInCreatedTeacher)
            {
                Log.Error($"Вход в созданный аккаунт, с именем {teacher.firstName} и фамилией {teacher.lastName} с ролью {teacher.GetRoleName()}, не выполнен");
            }
        }

        public void CreateLesson(ScheduleHomePage homePage)
        {
            DayOfWeek lessonDayOfWeek = DayOfWeek.Monday;
            int lessonNumber = 1;
            AudienceType audienceType = new AudienceType();
            Group group = new Group();
            Teacher teacher = new Teacher();
            Audience audience = new Audience(audienceType);
            Subject subject = new Subject(audienceType);
            
            Lesson lesson = new Lesson(lessonDayOfWeek, lessonNumber, subject, audience, teacher, group);

            homePage = audienceType.Create(homePage).LeftMenu.OpenSchedule();

            homePage = group.Create(homePage).LeftMenu.OpenSchedule();

            homePage = subject.Create(homePage).LeftMenu.OpenSchedule();

            homePage = audience.Create(homePage).LeftMenu.OpenSchedule();

            homePage = teacher.Create(homePage).LeftMenu.OpenSchedule();

            homePage = group.AddSubject(homePage, subject).LeftMenu.OpenSchedule();

            homePage = teacher.AddTeachingSubject(homePage, subject).LeftMenu.OpenSchedule();

            homePage
                .SelectGroup(group)
                .OpenAddLessonForm(lesson)
                .FillClassData(lesson)
                .SaveChanges();

            if (!homePage.isLessonRepresentedInSchedule(lesson))
            {
                Log.Error($"Созданая пара, по предмету {subject.title} в аудитории {audience.title}" +
                    $", не отображается в окне пары: {lesson.GetNumberDayOfWeek()} день недели, {lessonNumber} номер пары");
            }
        }
    }
}
