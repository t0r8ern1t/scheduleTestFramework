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
        public ScheduleHomePage Login(User user) // тут проблема у меня, при повторном логине у меня уже написано admin в поле логина
        {
            WebDriverActions.OpenUrl("http://project/login/");
            new WebItem("//input[@name='USER_LOGIN']", "Поле ввода логина")
                .SendKeys(user.Login);
            new WebItem("//input[@name='USER_PASSWORD']", "Поле ввода пароля")
                .SendKeys(user.Password);
            new WebItem("//input[@name='Login']", "Кнопка входа")
                .Click();
            return new ScheduleHomePage();
        }
    }
}
