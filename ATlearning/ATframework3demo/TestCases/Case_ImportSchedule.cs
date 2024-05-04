using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_ImportSchedule : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Импорт расписания из файла", homePage => ImportSchedule(homePage)));
            return caseCollection;
        }

        public void ImportSchedule(ScheduleHomePage homePage)
        {
            string file_path = "C:/Users/Tawoker/Desktop/Bitrix/Final Project/Schedules/example-1.xls";
            bool isScheduleImported = homePage
                    .LeftMenu.OpenImportPanel()
                    .ImportSchedule(file_path)
                    .IsScheduleImported();

            if (!isScheduleImported)
            {
                Log.Error($"При импорте расписания {file_path}, произошла ошибка");
            }
        }
    }
}
