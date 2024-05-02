using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class UserEditForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem FirstNameField =>
            new WebItem("//input[@name='NAME']", "Поле ввода имени");

        public static WebItem LastNameField =>
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии");

        public static WebItem EmailField =>
            new WebItem("//input[@name='EMAIL']", "Поле ввода почты");

        public static WebItem RoleSelector =>
            new WebItem("//select[@name='ROLE']", "Селектор изменения роли");

        public UserEditForm SelectRole(string roleName)
        {
            RoleSelector.Click();
            new WebItem($"//option[text()='{roleName}']", $"Опция выбора с текстом {roleName}")
                .Click();
            return this;
        }

        public UserEditForm FillUserData(ScheduleUser user)
        {
            FirstNameField.SendKeys(user.firstName);
            LastNameField.SendKeys(user.lastName);
            EmailField.SendKeys(user.email);
            SelectRole(user.GetRoleName());
            return this;
        }
    }
}
