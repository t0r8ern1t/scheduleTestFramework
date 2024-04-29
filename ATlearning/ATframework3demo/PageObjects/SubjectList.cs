using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class SubjectList : ScheduleHomePage
    {
        public static WebItem AddSubjectButton =>
            new WebItem("//a[@id='add-button']", "Кнопка добавления пользователя");

        public SubjectCreateForm OpenSubjectCreateForm()
        {
            AddSubjectButton.Click();
            return new SubjectCreateForm();
        }
    }
}
