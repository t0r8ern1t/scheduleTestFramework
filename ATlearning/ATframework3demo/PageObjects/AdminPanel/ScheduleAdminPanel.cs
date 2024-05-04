﻿using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.AdminPanel
{
    public class ScheduleAdminPanel
    {
        public static WebItem SubjectsButton =>
    new WebItem("//a[@href='/admin/#subject']", "Кнопка Предметы");
        public static WebItem UsersButton =>
    new WebItem("//a[@href='/admin/#user']", "Кнопка Пользователи");
        public static WebItem GroupsButton =>
    new WebItem("//a[@href='/admin/#group']", "Кнопка Группы");
        public static WebItem ClassroomsButton =>
    new WebItem("//a[@href='/admin/#audience']", "Кнопка Аудитории");
        public static WebItem ClasroomTypesButton =>
    new WebItem("//a[@href='/admin/#audienceType']", "Кнопка Типы аудиторий");

        public ScheduleUsersPage OpenUsersList()
        {
            UsersButton.Click();
            return new ScheduleUsersPage();
        }
    }
}
