﻿using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.CreateForms;

namespace ATframework3demo.TestEntities
{
    public class Audience
    {
        public Audience(AudienceType type)
        {
            title = $"{new Random().Next(1000000000)}";
            this.type = type;
        }

        public string title { get; set; }
        
        public AudienceType type { get; set; }

        public AudienceCreateForm Create(AdminPanel adminPanel)
        {
            return adminPanel
                    .OpenAudienceList()
                    .OpenCreateAudienceForm()
                    .AddAudience(this);
        }
    }
}
