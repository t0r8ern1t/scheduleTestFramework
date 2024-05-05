using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.TestEntities;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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

        public static WebItem EntitySelectionButton=>
            new WebItem("//button[@id='group-selection-button']", "Кнопка выбора сущности для отображения"); //потом локатор будет //button[@id='entity-selection-button']

        public ScheduleLoginPage GoToLogin()
        {
            return new ScheduleLoginPage();
        }

        public ScheduleAdminPanel OpenAdminPanel()
        {
            AdminPanelButton.Click();
            return new ScheduleAdminPanel();
        }

        public ScheduleCreateClassPage AddClass(ScheduleClass myclass)
        {
            string xpath = "//button[@id='button-add-" + (int)myclass.Day + "-" + myclass.Number + "']";
            new WebItem(xpath, $"Кнопка добавления пары #{myclass.Number} в день {myclass.Day}").Click();

            return new ScheduleCreateClassPage();
        }

        public ScheduleHomePage ChooseGroup(ScheduleClass myclass)
        {
            new WebItem("//input[@id='entity-selection-button']", "Строка поиска группы на странице расписания").SendKeys(myclass.Group.Title);
            new WebItem($"//a[text()='{myclass.Group.Title}']", $"Группа {myclass.Group.Title}").Click();
            return this;
        }

        public ScheduleHomePage IsClassPresent(ScheduleClass myclass, bool shouldBePresent)
        {

            string cellXpath = $"//div[@id='dropdown-{(int)myclass.Day}-{myclass.Number}']//ancestor::div[@class='box is-clickable couple m-0']";

            WebItem subject = new WebItem(cellXpath+$"//child::p[contains(text(), {myclass.Subject.Title})]", "Предмет пары по искомому номеру и дню недели");
            bool isSubjectPresent = Waiters.WaitForCondition(() => subject.WaitElementDisplayed(), 1, 2, $"Ожидание появления строки '{myclass.Subject.Title}'");
            bool isPresent = isSubjectPresent;
            if (isSubjectPresent)
            {
                WebItem classroom = new WebItem(cellXpath + $"//child::p[contains(text(), {myclass.Classroom.Title})]", "Аудитория пары по искомому номеру и дню недели");
                bool isClassroomPresent = Waiters.WaitForCondition(() => classroom.WaitElementDisplayed(), 1, 2, $"Ожидание появления строки '{myclass.Classroom.Title}'");
                isPresent = isClassroomPresent;
                if (isClassroomPresent)
                {
                    WebItem group = new WebItem(cellXpath + $"//child::p[contains(text(), {myclass.Subject.Title})]", "Группа пары по искомому номеру и дню недели");
                    bool isGroupPresent = Waiters.WaitForCondition(() => group.WaitElementDisplayed(), 1, 2, $"Ожидание появления строки '{myclass.Group.Title}'");
                    isPresent= isGroupPresent;
                    if (isGroupPresent)
                    {
                        WebItem teacher = new WebItem(cellXpath + $"//child::p[contains(text(), {myclass.Teacher.FirstName})]", "Преподаватель пары по искомому номеру и дню недели");
                        bool isTeacherPresent = Waiters.WaitForCondition(() => teacher.WaitElementDisplayed(), 1, 2, $"Ожидание появления строки '{myclass.Teacher.FirstName}'");
                        isPresent = isTeacherPresent;
                    }
                }
            }

            if (shouldBePresent == isPresent)
            {
                if (isPresent)
                {
                    Log.Info($"Пара {myclass.Subject.Title} найдена");
                }
                else
                {
                    Log.Info($"Пара {myclass.Subject.Title} удалена");
                }
            }
            else
            {
                if (!isPresent)
                {
                    Log.Error($"Пара {myclass.Subject.Title} не найдена");
                }
                else
                {
                    Log.Error($"Пара {myclass.Subject.Title} не удалена");
                }
            }
            return this;
        }

        public ScheduleHomePage DeleteClass(ScheduleClass myclass)
        {
            new WebItem($"//button[@id='button-remove-{(int)myclass.Day}-{myclass.Number}']", $"Кнопка удаления пары #{myclass.Number} в день недели {(int)myclass.Day}").Click();
            WebDriverActions.Refresh();
            return new ScheduleHomePage();
        }
    }
}
