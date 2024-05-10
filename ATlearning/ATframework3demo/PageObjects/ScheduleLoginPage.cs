using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.PageObjects
{
    public class ScheduleLoginPage
    {
        public ScheduleHomePage Login(User user)
        {
            WebDriverActions.OpenUrl("http://project/login/");

            var loginField = new WebItem("//input[@name='USER_LOGIN']", "Поле ввода логина");
            loginField.SendKeys(user.Login);
            var passwordField = new WebItem("//input[@name='USER_PASSWORD']", "Поле ввода пароля");
            passwordField.SendKeys(user.Password);
            new WebItem("//input[@name='Login']", "Кнопка входа").Click();
            return new ScheduleHomePage();
        }
    }
}
