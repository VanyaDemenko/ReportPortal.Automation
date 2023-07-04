using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Interfaces.Components;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Launches.LaunchesDataTable
{
    public class LaunchesTable : Container
    {
        public IEnumerable<LaunchesTableRow> LaunchesTableRows => SelectAll<LaunchesTableRow>(By.XPath(".//div[@class = 'gridRow__grid-row-wrapper--1dI9K']"));

        public string GetControlValueFromLaunchWithName(string controlTitle, string name)
            => (GetLaunchesTableRowByName(name).GetComponent<Container>(controlTitle) as IGetValue).GetValue();

        public LaunchesTableRow GetLaunchesTableRowByName(string name)
            => LaunchesTableRows.First(row => row.Name.GetValue().Equals(name));

        public void WaitForLoaded() => DriverProvider.Wait.Until((x) => LaunchesTableRows.Any());
    }
}
