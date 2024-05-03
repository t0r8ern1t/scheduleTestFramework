using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class LessonCreateForm
    {
        Dictionary<string, (string, string)> selectors = new Dictionary<string, (string, string)>
        {
            ["subject"] = ("//select[@id='subject-select']", "предмет"),
            ["audience"] = ("//select[@id='audience-select']", "аудитории"),
            ["teacher"] = ("//select[@id='teacher-select']", "преподаватель"),
            ["group"] = ("//select[@id='group-select']", "группа")
        };

        public static WebItem SubmitButton =>
            new WebItem("//button[@id='submit-form-button']", "Кнопка сохранения");

        public static WebItem CancelButton =>
            new WebItem("//button[@id='cancel-form-button']", "Кнопка отмены");

        private LessonCreateForm SelectOption((string, string) selectorInfo, string optionText)
        {
            new WebItem($"{selectorInfo.Item1}/option[contains(text(),'{optionText}')]"
                , $"Опция {optionText}, селектор {selectorInfo.Item2}")
                .Click();
            return this;
        }

        private LessonCreateForm OpenSelector((string, string) selectorInfo)
        {
            new WebItem($"{selectorInfo.Item1}"
                , $"Селектор {selectorInfo.Item2}")
                .Click();
            return this;
        }

        public LessonCreateForm SelectEntity((string, string) selectorInfo, string optionText)
        {
            OpenSelector(selectorInfo);
            SelectOption(selectorInfo, optionText);
            return this;
        }

        public LessonCreateForm SelectSubject(Subject subject)
        {
            SelectEntity(selectors["subject"], subject.title);
            return this;
        }

        public LessonCreateForm SelectAudience(Audience audience)
        {
            SelectEntity(selectors["audience"], audience.title);
            return this;
        }

        public LessonCreateForm SelectTeacher(Teacher teacher)
        {
            SelectEntity(selectors["teacher"], $"{teacher.firstName} {teacher.lastName}");
            return this;
        }

        public LessonCreateForm SelectGroup(Group group)
        {
            SelectEntity(selectors["group"], group.title);
            return this;
        }

        public LessonCreateForm FillClassData(Lesson lesson)
        {
            SelectSubject(lesson.subject);
            SelectAudience(lesson.audience);
            SelectGroup(lesson.group);
            SelectTeacher(lesson.teacher);
            return this;
        }

        public ScheduleHomePage SaveChanges()
        {
            SubmitButton.Click();
            return new ScheduleHomePage();
        }
    }
}
