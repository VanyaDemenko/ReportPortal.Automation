using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage;
using ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem.DashboardWidget;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem
{
    public class DashboardItemPage : ReportPortalPage
    {
        public IEnumerable<WidgetItem> Widgets => SelectAll<WidgetItem>(By.XPath("//div[contains(@class, 'widgetsGrid__widget')]"));

        public WidgetItem GetWidgetByName(string widgetName) =>
            Widgets.First(x => x.Header.Name.GetValue().Equals(widgetName));

        public void WaitForLoaded() => DriverProvider.Wait.Until((x) => Widgets.Any());
    }
}
