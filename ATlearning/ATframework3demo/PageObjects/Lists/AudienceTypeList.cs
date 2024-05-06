using ATframework3demo.PageObjects.CreateForms;

namespace ATframework3demo.PageObjects.Lists
{
    public class AudienceTypeList : EntityList
    {
        public AudienceTypeCreateForm OpenCreateAudienceTypeForm()
        {
            AddButton.Click();
            return new AudienceTypeCreateForm();
        }
    }
}
