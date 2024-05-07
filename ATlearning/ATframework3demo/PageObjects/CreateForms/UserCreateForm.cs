using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CreateForms
{
    public class UserCreateForm
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public static WebItem LoginField =>
            new WebItem("//input[@name='LOGIN']", "Поле ввода логина");

        public static WebItem FirstNameField =>
            new WebItem("//input[@name='NAME']", "Поле ввода имени");

        public static WebItem LastNameField =>
            new WebItem("//input[@name='LAST_NAME']", "Поле ввода фамилии");

        public static WebItem EmailField =>
            new WebItem("//input[@name='EMAIL']", "Поле ввода почты");

        public static WebItem PasswordField =>
            new WebItem("//input[@name='PASSWORD']", "Поле ввода пароля");

        public static WebItem ConfirmPasswordField =>
            new WebItem("//input[@name='CONFIRM_PASSWORD']", "Поле ввода подтверждения пароля");

        public static WebItem RoleSelector =>
            new WebItem("//select[@name='ROLE']", "Селектор изменения роли");

        public static WebItem SubmitButton =>
            new WebItem("//button[@type='submit']", "Кнопка сохранения");

        public void FillBaseUserData(ScheduleUser user)
        {
            LoginField.SendKeys(user.login);
            FirstNameField.SendKeys(user.firstName);
            LastNameField.SendKeys(user.lastName);
            EmailField.SendKeys(user.email);
            PasswordField.SendKeys(user.password);
            ConfirmPasswordField.SendKeys(user.password);
            RoleSelector.SelectListItemByText(user.GetRoleName());
        }

        public UserCreateForm AddUser()
        {
            SubmitButton.Click();
            return this;
        }
    }
}