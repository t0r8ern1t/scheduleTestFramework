﻿using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace atFrameWork2.BaseFramework
{
    public class TestCase
    {
        public static TestCase RunningTestCase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Название тесткейса</param>
        /// <param name="body">Ссылка на метод тела кейса</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestCase(string title, Action<ScheduleHomePage> body)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Node = new TestCaseTreeNode(title);
            EnvType = TestCaseEnvType.Web;
        }

        int logCounter = 0;

        public void Execute(PortalInfo testPortal, Action uiRefresher)
        {
            Status = TestCaseStatus.running;
            uiRefresher.Invoke();
            RunningTestCase = this;
            logCounter++;
            CaseLogPath = Path.Combine(Environment.CurrentDirectory, $"caselog{DateTime.Now:ddMMyyyyHHmmss}{logCounter}.html");
            Log.WriteHtmlHeader(CaseLogPath);
            uiRefresher.Invoke();

            try
            {
                Log.Info($"---------------Запуск кейса '{Title}'---------------");
                if (EnvType == TestCaseEnvType.Web)
                {
                    var scheduleLoginPage = new ScheduleLoginPage();
                    WebDriverActions.OpenUrl("http://project/login/");
                    var homePage = scheduleLoginPage.Login(testPortal.PortalAdmin);
                    Body.Invoke(homePage);
                }
                else
                {
                    
                }

            }
            catch (Exception e)
            {
                Log.Error($"Кейс не пройден, причина:{Environment.NewLine}{e}");
            }

            Log.Info($"---------------Кейс '{Title}' завершён---------------");

            try
            {
                if (BaseItem._defaultDriver != default)
                {
                    BaseItem.DefaultDriver.Quit();
                    BaseItem.DefaultDriver = default;
                }
            }
            catch (Exception) { }

            if (CaseLog.Any(x => x is LogMessageError))
                Status = TestCaseStatus.failed;
            else
                Status = TestCaseStatus.passed;

            RunningTestCase = default;
            uiRefresher.Invoke();
        }

        public string Title { get; set; }
        Action<ScheduleHomePage> Body { get; set; }
        public TestCaseTreeNode Node { get; set; }
        public string CaseLogPath { get; set; }
        public List<LogMessage> CaseLog { get; } = new List<LogMessage>();
        public TestCaseStatus Status { get; set; }
        public TestCaseEnvType EnvType { get; set; }
    }

    public enum TestCaseEnvType
    {
        Web,
        Mobile
    }
}
