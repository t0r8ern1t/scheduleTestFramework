using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class SubjectList : EntityList
    {
        public SubjectCreateForm OpenSubjectCreateForm()
        {
            AddButton.Click();
            return new SubjectCreateForm();
        }
    }
}
