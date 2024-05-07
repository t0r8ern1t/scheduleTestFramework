using ATframework3demo.TestEntities;
using OpenQA.Selenium.DevTools.V118.Autofill;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class TeacherCreateForm : UserCreateForm
    {
        private AddSubjectMenu AddSubjectMenu => new AddSubjectMenu();

        public TeacherCreateForm AddTeacher(Teacher teacher, List<Subject> subjects)
        {
            FillBaseUserData(teacher);
            AddSubjectMenu.AddSubjects(subjects);
            SubmitButton.Click();
            return this;
        }
    }
}
