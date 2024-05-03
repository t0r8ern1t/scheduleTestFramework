﻿using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.CreateForms;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Lists
{
    public class AudienceList : EntityList
    {
        public AudienceCreateForm OpenCreateAudienceForm()
        {
            AddButton.Click();
            return new AudienceCreateForm();
        }
    }
}
