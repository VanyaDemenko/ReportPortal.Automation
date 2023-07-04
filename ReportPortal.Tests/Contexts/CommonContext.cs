using ReportPortal.Tests.Contexts.Base;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Factories;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage;

namespace ReportPortal.Tests.Contexts
{
    public class CommonContext : IContext
    {
        private ReportPortalPage _reportPortalPage { get; }

        public CommonContext() => _reportPortalPage = EntryPageFactory.Create<ReportPortalPage>(DriverProvider.Driver);

        public void LogOutFromReportPortal()
        {
            _reportPortalPage.NotificationMessage.Element.WaitForElementToNotDisplayed();
            _reportPortalPage.LogOut();
            DriverHelper.WaitPageFullLoaded();
        }

        public void SelectNavigationMenuOption(string menuOption)
        {
            _reportPortalPage.SelectNavMenuOption(menuOption);
            DriverHelper.WaitPageFullLoaded();
        }
    }
}
