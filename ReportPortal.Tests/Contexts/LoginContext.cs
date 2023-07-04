using ReportPortal.Tests.Contexts.Base;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Factories;
using ReportPortal.Business.PageObjects.Pages.Login;

namespace ReportPortal.Tests.Contexts
{
    public class LoginContext : IContext
    {
        private LoginPage _loginPage { get; }

        public LoginContext() => _loginPage = EntryPageFactory.Create<LoginPage>(DriverProvider.Driver);

        public void LoginToReportPortal(string loginName, string password)
        {
            _loginPage.Login(loginName, password);
            _loginPage.NotificationMessage.Element.WaitForElementToDisplayed();
            DriverHelper.WaitPageFullLoaded();
        }
    }
}
