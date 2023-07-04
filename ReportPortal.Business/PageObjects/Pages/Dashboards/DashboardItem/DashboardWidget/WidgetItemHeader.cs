using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem.DashboardWidget
{
    public class WidgetItemHeader : Container
    {
        public BaseLabel Name => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'widget-name-block')]"));
    }
}
