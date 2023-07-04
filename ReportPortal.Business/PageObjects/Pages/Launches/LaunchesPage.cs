using OpenQA.Selenium;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage;
using ReportPortal.Business.PageObjects.Pages.Launches.LaunchesDataTable;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Pages.Launches
{
    public class LaunchesPage : ReportPortalPage
    {
        [Titles("Launches Table")]
        public LaunchesTable LaunchesTable => Select<LaunchesTable>(By.XPath("//div[@class = 'grid__grid--utIJA']"));
    }
}
