using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class ScheduleImportPage
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public ScheduleImportPage ImportSchedule(string schedule_file_path)
        {
            new WebItem("//input[@name='excel-file']", "Файловый инпут для расписания в формате excel-файла")
                .SendKeys(schedule_file_path);
            return this;
        }

        public bool IsScheduleImported()
        {
            return new WebItem("//div[@id='success']", "Уведомление об успешном импорте").WaitElementDisplayed();
        }
    }
}
