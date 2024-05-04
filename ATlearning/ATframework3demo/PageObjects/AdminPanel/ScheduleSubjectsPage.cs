using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleSubjectsPage
    {
        public ScheduleCreateSubjectPage CreateSubject()
        {
            new WebItem("//a[@id='add-button']", "Кнопка Добавить").Click();
            return new ScheduleCreateSubjectPage();
        }

        public ScheduleSubjectsPage IsSubjectPresent(ScheduleSubject subject, bool shouldBePresent)
        {
            new WebItem("//input[@id='search-input']", "Строка поиска").SendKeys(subject.Title);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            var myUser = new WebItem($"//div[contains(text(),'{subject.Title}')]", "Искомый предмет");

            bool isPresent = Waiters.WaitForCondition(() => myUser.AssertTextContains(subject.Title, default), 2, 6,
    $"Ожидание появления строки '{subject.Title}'");

            if (shouldBePresent == isPresent)
            {
                if (isPresent)
                {
                    Log.Info($"Предмет {subject.Title} найден");
                }
                else
                {
                    Log.Info($"Предмет {subject.Title} удален");
                }
            }
            else
            {
                if (!isPresent)
                {
                    Log.Error($"Предмет {subject.Title} не удален");
                }
                else
                {
                    Log.Error($"Предмет {subject.Title} не найден");
                }
            }
            return this;
        }

        public ScheduleEditSubjectPage OpenEditForm(ScheduleSubject subject)
        {
            var searchbar = new WebItem("//input[@id='search-input']", "Строка поиска");
            searchbar.Clear();
            searchbar.SendKeys(subject.Title);
            new WebItem("//a[@id='search-button']", "Кнопка Искать").Click();
            new WebItem($"//div[contains(text(),'{subject.Title}')]", "Искомый предмет").Click();
            return new ScheduleEditSubjectPage();
        }
    }
}
