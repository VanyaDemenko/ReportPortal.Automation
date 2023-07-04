using ReportPortal.Business.Drivers;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Factories;
using ReportPortal.Business.PageObjects.Pages.Dashboards;
using ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem;
using ReportPortal.Tests.Contexts.Base;

namespace ReportPortal.Tests.Contexts
{
    public class DashboardsContext : IContext
    {
        private DashboardsPage _dashboardsPage { get; }
        private DashboardItemPage _dashboardItemPage { get; }

        public DashboardsContext()
        {
            _dashboardsPage = EntryPageFactory.Create<DashboardsPage>(DriverProvider.Driver);
            _dashboardItemPage = EntryPageFactory.Create<DashboardItemPage>(DriverProvider.Driver);
        }

        public void SelectDashboardFromDashboardsTable(string dashboardName)
        {
            _dashboardsPage.DashboardsTable.WaitForLoaded();
            _dashboardsPage.DashboardsTable.SelectDashboardByName(dashboardName);
            _dashboardItemPage.WaitForLoaded();
        }

        public void ResizeWidget(string widgetName, int widthValue, int heightValue)
        {
            _dashboardItemPage.GetWidgetByName(widgetName).ResizeIcon.Element.Resize(widthValue, heightValue);
            _dashboardItemPage.WaitForReadyState();
        }

        public void DragAndDropWidget(string widgetName, int positionXValue, int positionYValue)
        {
            _dashboardItemPage.GetWidgetByName(widgetName).Header.Element.DragAndDrop(positionXValue, positionYValue);
            _dashboardItemPage.WaitForReadyState();
        }

        public int GetWidgetHeight(string widgetName) => _dashboardItemPage.GetWidgetByName(widgetName).Element.GetHeight();

        public int GetWidgetWidth(string widgetName) => _dashboardItemPage.GetWidgetByName(widgetName).Element.GetWidth();

        public int GetWidgetTransformPositionX(string widgetName) => _dashboardItemPage.GetWidgetByName(widgetName).Element.GetTransformPositionX();

        public int GetWidgetTransformPositionY(string widgetName) => _dashboardItemPage.GetWidgetByName(widgetName).Element.GetTransformPositionY();
    }
}
