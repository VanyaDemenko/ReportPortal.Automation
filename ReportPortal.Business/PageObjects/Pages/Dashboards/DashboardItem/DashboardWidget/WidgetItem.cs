using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem.DashboardWidget
{
    public class WidgetItem : Container
    {
        public WidgetItemHeader Header => Select<WidgetItemHeader>(By.XPath(".//div[contains(@class, 'widget__widget-header')]"));

        public BaseButton ResizeIcon => Select<BaseButton>(By.XPath(".//span[contains(@class, 'resizable-handle')]"));
    }
}
