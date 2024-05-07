using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.CreateForms;

namespace ATframework3demo.TestEntities
{
    public class AudienceType
    {
        public AudienceType()
        {
            title = "Type" + DateTime.Now.Ticks;
        }

        public AudienceType(string title)
        {
            this.title = "Type" + DateTime.Now.Ticks;
        }

        public string title { get; set; }

        public AudienceTypeCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenAudienceTypeList()
                    .OpenCreateAudienceTypeForm()
                    .AddAudienceType(this);
        }
    }
}
