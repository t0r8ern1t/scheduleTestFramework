﻿using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class UserList : EntityList
    {
        public UserCreateForm OpenCreateUserForm()
        {
            AddButton.Click();
            return new UserCreateForm();
        }

        public UserEditForm OpenEditUserForm(ScheduleUser user)
        {
            SearchEntity(user.lastName);
            new WebItem($"//div[contains(text(), '{user.firstName}') and contains(text(), '{user.lastName}')]"
                , $"Кнопка пользователя {user.login}")
                .Click();
            return new UserEditForm();
        }

        public TeacherEditForm OpenEditTeacherForm(ScheduleUser user)
        {
            SearchEntity(user.lastName);
            new WebItem($"//div[contains(text(), '{user.firstName}') and contains(text(), '{user.lastName}')]"
                , $"Кнопка пользователя {user.login}")
                .Click();
            return new TeacherEditForm();
        }
    }
}
