using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Login.LoginSection
{
    public class LoginContainer : Container
    {
        public BaseTextField LoginTextField => Select<BaseTextField>(By.XPath(".//input[@name = 'login']"));
        
        public BaseTextField PasswordTextField => Select<BaseTextField>(By.XPath(".//input[@name = 'password']"));

        public BaseButton LoginButton => Select<BaseButton>(By.XPath(".//button[text() = 'Login']"));
    }
}
