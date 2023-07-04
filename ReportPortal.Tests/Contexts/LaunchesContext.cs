using ReportPortal.Tests.Contexts.Base;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Factories;
using ReportPortal.Business.PageObjects.Pages.Launches;

namespace ReportPortal.Tests.Contexts
{
    public class LaunchesContext : IContext
    {
        private LaunchesPage _launchesPage { get; }

        public LaunchesContext() => _launchesPage = EntryPageFactory.Create<LaunchesPage>(DriverProvider.Driver);

        public string GetControlDataFromLaunchWithName(string controlTitle, string launchName)
        {
            _launchesPage.LaunchesTable.WaitForLoaded();
            return _launchesPage.LaunchesTable.GetControlValueFromLaunchWithName(controlTitle, launchName);
        }
    }
}
