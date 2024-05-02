﻿using atFrameWork2.BaseFramework;
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
            return caseCollection;
        }

        public void CreateLesson(ScheduleHomePage homePage)
        {
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            int number = 1;
            AudienceType audienceType = AudienceType.Lecture;
            Group group = new Group();
            Teacher teacher = new Teacher();
            Subject subject = new Subject(audienceType);
            Audience audience = new Audience(audienceType);
            Lesson lesson = new Lesson(dayOfWeek, number, subject, audience, teacher, group);

            CreateGroup(homePage, group);
            homePage.OpenSchedule();
            CreateSubject(homePage, subject);
            homePage.OpenSchedule();
            CreateAudience(homePage, audience);
            homePage.OpenSchedule();
            CreateTeacher(homePage, teacher);
            homePage.OpenSchedule();
            AddSubjectToGroupe(homePage, subject, group);
            homePage.OpenSchedule();
            AddSubjectToTeacher(homePage, subject, teacher);
            homePage.OpenSchedule();

            homePage
                .SelectGroup(group)
                .OpenAddLessonForm(lesson)
                .FillClassData(lesson)
                .SaveChanges();

            if (!homePage.isLessonRepresentInSchedule(lesson))
            {
                Log.Error("Созданая пара не отображается");
            }
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

        public void CreateGroup(ScheduleHomePage homePage, Group group)
        {
            homePage
                .OpenAdminPanel()
                .OpenGroupList()
                .OpenCreateGroupForm()
                .AddGroup(group);
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

        public void AddSubjectToGroupe(ScheduleHomePage homePage, Subject subject, Group group)
        {
            homePage
                .OpenAdminPanel()
                .OpenGroupList()
                .OpenEditGroupForm(group)
                .AddSubject(subject)
                .SaveChanges();
        }

        public void AddSubjectToTeacher(ScheduleHomePage homePage, Subject subject, Teacher teacher)
        {
            homePage
                .OpenAdminPanel()
                .OpenUserList()
                .OpenEditTeacherForm(teacher)
                .AddSubject(subject)
                .SaveChanges();
        }
    }
}
