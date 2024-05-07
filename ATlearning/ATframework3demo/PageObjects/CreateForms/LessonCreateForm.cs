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

        public static WebItem EntitySelector((string, string) selectorInfo) =>
            new WebItem(selectorInfo.Item1, selectorInfo.Item2);

        public static WebItem SubmitButton =>
            new WebItem("//button[@id='submit-form-button']", "Кнопка сохранения");

        public static WebItem CancelButton =>
            new WebItem("//button[@id='cancel-form-button']", "Кнопка отмены");

        public LessonCreateForm SelectSubject(Subject subject)
        {
            EntitySelector(selectors["subject"]).SelectListItemByText(subject.title);
            return this;
        }

        public LessonCreateForm SelectAudience(Audience audience)
        {
            EntitySelector(selectors["audience"]).SelectListItemByText(audience.title);
            return this;
        }

        public LessonCreateForm SelectTeacher(Teacher teacher)
        {
            EntitySelector(selectors["teacher"]).SelectListItemByText($"{teacher.firstName} {teacher.lastName}");
            return this;
        }

        public LessonCreateForm SelectGroup(Group group)
        {
            EntitySelector(selectors["group"]).SelectListItemByText(group.title);
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
