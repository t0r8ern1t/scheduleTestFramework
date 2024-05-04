﻿using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.AdminPanel;
using ATframework3demo.PageObjects.AdminPanel.Classrooms;
using ATframework3demo.PageObjects.AdminPanel.ClassroomTypes;
using ATframework3demo.PageObjects.AdminPanel.Groups;
using ATframework3demo.PageObjects.AdminPanel.Subjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class NotCase_CreateObjects
    {
        public ScheduleAdminPanel CreateClassroomType(ScheduleClassroomType type, ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание типа аудитории");
            adminPanel
                // открываем список типов аудиторий
                .OpenClassroomTypesList()
                // нажимаем добавить
                .CreateClassroomType()
                // заполняем поля, сохраняем
                .FillFields(type)
                // проверяем, есть ли тип в списке
                .IsClassroomTypePresent(type, true)
                // возвращяемся на админ. панель
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateClassroom(ScheduleClassroom classroom, ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание аудитории");
            // проверяем существует ли нужный тип, если нет - создаем
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(classroom.Type))
            {
                adminPanel = CreateClassroomType(classroom.Type, classroomTypesList.Return());
            }
            else
            {
                adminPanel = classroomTypesList.Return();
            }
            adminPanel
                // открываем список аудиторий
                .OpenClassroomsList()
                // нажимаем добавить
                .CreateClassroom()
                // заполняем форму
                .FillFields(classroom)
                // проверяем есть ли тип в списке
                .IsClassroomPresent(classroom, true)
                // возвращаемся на админ панель
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateSubject(ScheduleSubject subject, ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание предмета");
            // проверяем, существует ли нужный тип аудитории, если нет - создаем
            ScheduleClassroomTypesPage classroomTypesList = adminPanel.OpenClassroomTypesList();
            if (!classroomTypesList.FindClassroomType(subject.Type))
            {
                adminPanel = CreateClassroomType(subject.Type, classroomTypesList.Return());
            }
            else 
            {
                adminPanel = classroomTypesList.Return();  
            }
            adminPanel
                // открываем список предметов
                .OpenSubjectsList()
                // нажимаем добавить
                .CreateSubject()
                // заполняем форму
                .FillFields(subject)
                // проверяем, есть ли предмет в списке
                .IsSubjectPresent(subject, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateGroup(ScheduleGroup group, ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание группы");
            // проверяем существуют ли предметы, указанные в параметрах группы
            // если нет - создаем
            ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
            foreach (var subject in group.Subjects)
            { 
                if (!subjectsList.FindSubject(subject))
                {
                    adminPanel = CreateSubject(subject, subjectsList.Return());
                }
            }
            adminPanel = subjectsList.Return();

            adminPanel
                // открываем список групп
                .OpenGroupsList()
                // нажимаем создать
                .CreateGroup()
                // заполняем форму
                .FillFields(group)
                // проверяем, есть ли группа в списке
                .IsGroupPresent(group, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }

        public ScheduleAdminPanel CreateUser(ScheduleUser user, ScheduleAdminPanel adminPanel)
        {
            Log.Info("Создание пользователя");
            switch (user.Role) {
                // если пользователь - преподаватель, проверяем существуют ли предметы, указанные в параметрах
                // если нет - создаем
                case UserRole.Teacher:
                    ScheduleSubjectsPage subjectsList = adminPanel.OpenSubjectsList();
                    foreach (var subject in user.Subjects)
                    {
                        if (!subjectsList.FindSubject(subject))
                        {
                            adminPanel = CreateSubject(subject, subjectsList.Return());
                        }
                    }
                    adminPanel = subjectsList.Return();
                    break;
                // если пользователь - студент, проверяем, существует ли его группа
                // если нет - создаем
                case UserRole.Student:
                    ScheduleGroupsPage groupsList = adminPanel.OpenGroupsList();
                    if (!groupsList.FindGroup(user.Group))
                    {
                        groupsList.Return();
                        adminPanel = CreateGroup(user.Group, adminPanel);
                    }
                    adminPanel = groupsList.Return();
                    break;
                case UserRole.Admin:
                // если пользователь админ, все ок, продолжаем
                    break;
            }

            adminPanel
                // открываем список пользователей
                .OpenUsersList()
                // нажимаем добавить
                .CreateUser()
                // заполням форму
                .FillFields(user)
                // проверяем, есть ли пользователь в списке
                .IsUserPresent(user, true)
                // возвращаемся в админ. панель
                .Return();
            return adminPanel;
        }

        public ScheduleHomePage CreateClass(ScheduleClass myclass, ScheduleAdminPanel adminPanel) 
        {
            Log.Info("Создание пары");
            // создаем объекты всех параметров
            adminPanel = CreateSubject(myclass.Subject, adminPanel);
            adminPanel = CreateClassroom(myclass.Classroom, adminPanel);
            adminPanel = CreateGroup(myclass.Group, adminPanel);
            adminPanel = CreateUser(myclass.Teacher, adminPanel);

            adminPanel
                // открываем главную страницу
                .OpenHomePage()
                // выбираем нужную группу в дропдауне
                .ChooseGroup(myclass)
                // нажимаем на плюсик в нужной ячейке
                .AddClass(myclass)
                // заполняем форму
                .FillFields(myclass)
                // проверяем, добавилась ли пара в ячейку
                .IsClassPresent(myclass, true);

            return new ScheduleHomePage();
        }
    }
}
