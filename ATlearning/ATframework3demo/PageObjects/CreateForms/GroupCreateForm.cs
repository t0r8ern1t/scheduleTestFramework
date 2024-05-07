﻿using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.EditForms;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class GroupCreateForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        private AddSubjectMenu AddSubjectMenu => new AddSubjectMenu();

        public static WebItem TitleField =>
            new WebItem("//input[@name='TITLE']", "Поле ввода названия группы");

        public static WebItem SubmitButton =>
            new WebItem("//button[@type='submit']", "Кнопка сохранения");

        public GroupCreateForm AddGroup(Group group, List<Subject> subjects)
        {
            AddSubjectMenu.AddSubjects(subjects);
            TitleField.SendKeys(group.title);
            SubmitButton.Click();
            return this;
        }
    }
}
