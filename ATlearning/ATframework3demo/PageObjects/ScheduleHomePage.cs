using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class ScheduleHomePage
    {
        public static WebItem OpenProfileButton =>
            new WebItem("//a[@href='/profile/']", "Кнопка перехода в профиль");

        public static WebItem LogoutButton =>
            new WebItem("//a[@href='/logout/']", "Кнопка выхода из учетной записи");

        public static WebItem LoginButton =>
            new WebItem("//a[@href='/login/']", "Кнопка выхода из учетной записи");

        public static WebItem AdminPanelButton =>
            new WebItem("//a[@href='/admin/']", "Кнопка перехода в админ панель");

        public static WebItem SchedulingButton =>
            new WebItem("//a[@href='/scheduling/']", "Кнопка перехода к составлению расписания");

        public static WebItem BackToSchedule=>
            new WebItem("//a[@href='/']", "Кнопка перехода к расписанию");

        private static WebItem EntitySelectionButton=>
            new WebItem("//input[@id='entity-selection-button']", "Кнопка выбора сущности для отображения");

        private static WebItem GropeShowModeButton=>
            new WebItem("//ul[@id='schedule-display-entity-list']//child::a[contains(@href, 'group')]//ancestor::li"
                , "Кнопка выбора режима отображения по группе");

        private static WebItem AudienceShowModeButton =>
            new WebItem("//ul[@id='schedule-display-entity-list']/li//child::a[contains(@href, 'audience')]"
                , "Кнопка выбора режима отображения по аудитории");

        private static WebItem TeacherShowModeButton =>
            new WebItem("//ul[@id='schedule-display-entity-list']/li//child::a[contains(@href, 'teacher')]"
                , "Кнопка выбора режима отображения по преподавателю");

        public ScheduleHomePage Logout()
        {
            LogoutButton.Click();
            return new ScheduleHomePage();
        }

        public ScheduleLoginPage OpenLoginPage()
        {
            LoginButton.Click();
            return new ScheduleLoginPage();
        }

        public AdminPanel OpenAdminPanel()
        {
            AdminPanelButton.Click();
            return new AdminPanel();
        }

        public ScheduleHomePage OpenSchedule()
        {
            BackToSchedule.Click();
            return this;
        }

        public bool isLogined()
        {
            return LogoutButton.WaitElementDisplayed();
        }

        public ScheduleHomePage ChooseShowGroupsMode()
        {
            GropeShowModeButton.Click();
            return this;
        }

        public ScheduleHomePage ChooseShowTeachersMode()
        {
            TeacherShowModeButton.Click();
            return this;
        }

        public ScheduleHomePage ChooseShowAudiencesMode()
        {
            AudienceShowModeButton.Click();
            return this;
        }

        public ScheduleHomePage SelectGroup(Group group)
        {
            EntitySelectionButton.Click();
            new WebItem($"//div[@id='entity-selection']/div[@class='dropdown-menu']//child::a[text()='{group.title}']"
                , $"Кнопка выбора группы {group.title}")
                .Click();
            Waiters.StaticWait_s(2);
            return this;
        }

        public LessonCreateForm OpenAddLessonForm(Lesson lesson)
        {
            new WebItem($"//button[@id='button-{lesson.GetNumberDayOfWeek()}-{lesson.number}']"
                , $"Кнопка опций окна для пары, в день недели {lesson.dayOfWeek}, номер пары {lesson.number}")
                .Click();
            new WebItem($"//button[@id='button-add-{lesson.GetNumberDayOfWeek()}-{lesson.number}']"
                , $"Кнопка добавить пару, в день недели {lesson.dayOfWeek}, номер пары {lesson.number}")
                .Click();
            return new LessonCreateForm();
        }

        public string getLessonTextXPath(Lesson lesson)
        {
            return $"//div[@id='dropdown-{lesson.GetNumberDayOfWeek()}-{lesson.number}']//ancestor::div[@class='box is-clickable couple m-0']";
        }

        public bool isLessonRepresentInSchedule(Lesson lesson)
        {
            string lessonWindowXPath = getLessonTextXPath(lesson);
            if (new WebItem($"{lessonWindowXPath}//child::p[text()='{lesson.subject.title}']"
                , $"Название предмета {lesson.subject.title}").WaitElementDisplayed() 
                && new WebItem($"{lessonWindowXPath}//child::p[text()='{lesson.audience.title}']"
                , $"Название аудитории {lesson.audience.title}").WaitElementDisplayed()
                && new WebItem($"{lessonWindowXPath}//child::p[text()='{lesson.group.title}']"
                , $"Название группы {lesson.group.title}").WaitElementDisplayed()
                && new WebItem($"{lessonWindowXPath}//child::p[text()='{lesson.teacher.firstName} {lesson.teacher.lastName}']"
                , $"Имя и фамилия преподавателя {lesson.teacher.firstName} {lesson.teacher.lastName}").WaitElementDisplayed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
