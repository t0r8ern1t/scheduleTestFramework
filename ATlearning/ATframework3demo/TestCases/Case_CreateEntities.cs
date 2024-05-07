using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
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
            AdminPanel adminPanel = homePage.LeftMenu.OpenAdminPanel();

            audience.type
                .Create(adminPanel)
                .LeftMenu.OpenAdminPanel();

            var isAudienceRepresentedInAudienceList = audience.Create(adminPanel)
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
            AdminPanel adminPanel = homePage.LeftMenu.OpenAdminPanel();

            subject.audienceType
                .Create(adminPanel)
                .LeftMenu.OpenAdminPanel();

            var isSubjectRepresentedInSubjectList = subject.Create(adminPanel)
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
            AdminPanel adminPanel = homePage.LeftMenu.OpenAdminPanel();

            bool isGroupRepresentedInGrouptList = group.Create(adminPanel)
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
            AdminPanel adminPanel = homePage.LeftMenu.OpenAdminPanel();

            bool isLoginedInCreatedTeacher = teacher.Create(adminPanel)
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

            AdminPanel adminPanel = homePage.LeftMenu.OpenAdminPanel();

            adminPanel = audienceType.Create(adminPanel).LeftMenu.OpenAdminPanel();

            adminPanel = group.Create(adminPanel).LeftMenu.OpenAdminPanel();

            adminPanel = subject.Create(adminPanel).LeftMenu.OpenAdminPanel();

            adminPanel = audience.Create(adminPanel).LeftMenu.OpenAdminPanel();

            adminPanel = teacher.Create(adminPanel).LeftMenu.OpenAdminPanel();

            adminPanel = group.AddSubject(adminPanel, subject).LeftMenu.OpenAdminPanel();

            homePage = teacher.AddTeachingSubject(adminPanel, subject).LeftMenu.OpenSchedule();

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
