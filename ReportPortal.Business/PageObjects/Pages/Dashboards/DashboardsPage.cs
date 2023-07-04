using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage;
using ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardsDataTable;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards
{
    public class DashboardsPage : ReportPortalPage
    {
        [Titles("Add New Dashboard")]
        public BaseButton AddNewDashboardButton => Select<BaseButton>(By.XPath("//button[.//span[text() = 'Add New Dashboard']]"));

        [Titles("Dashboards Table")]
        public DashboardsTable DashboardsTable => Select<DashboardsTable>(By.XPath("//div[contains(@class, 'dashboardTable__dashboard-table')]"));
    }
}
