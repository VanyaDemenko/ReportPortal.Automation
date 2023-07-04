using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardsDataTable
{
    public class DashboardsTable : Container
    {
        public IEnumerable<DashboardsTableRow> DashboardsTableRows => SelectAll<DashboardsTableRow>(By.XPath(".//div[contains(@class, 'gridRow__grid-row')][not(contains(@class, 'wrapper'))]"));

        public void SelectDashboardByName(string name) =>
            DashboardsTableRows.First(x => x.Name.GetValue().Equals(name)).Name.Element.Click();

        public void WaitForLoaded() => DriverProvider.Wait.Until((x) => DashboardsTableRows.Any());
    }
}
