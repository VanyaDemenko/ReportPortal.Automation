using OpenQA.Selenium;
using ReportPortal.Business.PageObjects.Base;
using ReportPortal.Business.PageObjects.Pages.Login.LoginSection;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Pages.Login
{
    public class LoginPage : BasePage
    {
        [Titles("Login Section")]
        public LoginContainer LoginSection => Select<LoginContainer>(By.XPath("//div[./div[contains(@class, 'pageBlockContainer')]]"));

        public void Login(string loginName, string password)
        {
            LoginSection.LoginTextField.SetValue(loginName);
            LoginSection.PasswordTextField.SetValue(password);
            LoginSection.LoginButton.Element.Click();
        }
    }
}
