using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.PageObjects
{
    public class ScheduleLoginPage
    {
        public static WebItem LoginField =>
            new WebItem("//input[@name='USER_LOGIN']", "Поле ввода логина");

        public static WebItem PasswordField =>
            new WebItem("//input[@name='USER_PASSWORD']", "Поле ввода пароля");

        public static WebItem SaveSessionCheckbox =>
            new WebItem("//input[@name='USER_LOGIN']", "Поле ввода логина");

        public static WebItem LoginButton =>
            new WebItem("//input[@name='Login']", "Кнопка входа");

        public ScheduleHomePage Login(string login, string password, bool saveSession = false)
        {
            LoginField.Clear();
            PasswordField.Clear();
            LoginField.SendKeys(login);
            PasswordField.SendKeys(password);
            LoginButton.Click();    
            return new ScheduleHomePage();
        }

        public ScheduleHomePage Login(User user)
        {
            return Login(user.Login, user.Password);
        }

        public ScheduleHomePage Login(ScheduleUser user)
        {
            return Login(user.login, user.password);
        }
    }
}
