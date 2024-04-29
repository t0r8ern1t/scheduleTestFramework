using atFrameWork2.SeleniumFramework;
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

        public static WebItem EntitySelectionButton=>
            new WebItem("//button[@id='group-selection-button']", "Кнопка выбора сущности для отображения"); //потом локатор будет //button[@id='entity-selection-button']

        public ScheduleLoginPage GoToLogin()
        {
            return new ScheduleLoginPage();
        }
    }
}
