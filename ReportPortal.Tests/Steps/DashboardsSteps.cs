using NUnit.Framework;
using ReportPortal.Tests.Contexts;
using ReportPortal.Core.Enums;
using ReportPortal.Business.PageObjects.Pages.Dashboards;
using ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardItem;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    internal class DashboardsSteps
    {
        private readonly ComponentContext<DashboardsPage> _dashboardsComponentContext = new();
        private readonly ComponentContext<DashboardItemPage> _dashboardItemComponentContext = new();
        private readonly DashboardsContext _dashboardsContext = new();

        [When(@"I select the dashboard with '(.*)' name on the Dashboards page")]
        public void WhenISelectTheDashboardWithNameOnTheDashboardsPage(string dashboardName)
        {
            _dashboardsContext.SelectDashboardFromDashboardsTable(dashboardName);
        }

        [When(@"I scroll to '(.*)' control at the '(.*)' container on the Dashboard Item page")]
        public void WhenIScrollToControlAtTheContainerOnTheDashboardItemPage(string controlName, string containerName)
        {
            _dashboardItemComponentContext.ScrollToComponentAtTheContainer(controlName, containerName);
        }

        /* Actions Validation */

        [Then(@"'(.*)' control (is|is not) '(.*)' on the Dashboards page")]
        public void ThenControlIsOnTheDashboardsPage(string controlName, bool expectedState, ElementState stateToCheck)
        {
            var actualState = _dashboardsComponentContext.GetContainerState(controlName, stateToCheck);
            Assert.AreEqual(expectedState, actualState);
        }

        [Then(@"'(.*)' control at the '(.*)' container (is|is not) scrolled into view on the Dashboard Item page")]
        public void ThenControlAtTheContainerIsScrolledIntoViewOnTheDashboardItemPage(string controlName, string containerName, bool expectedState)
        {
            var actualState = _dashboardItemComponentContext.IsComponentAtTheContainerScrolledIntoView(controlName, containerName);
            Assert.AreEqual(expectedState, actualState);
        }

        [Then(@"I can resize the widget with '(.*)' name using '(.*)' width and '(.*)' height on the Dashboard Item page")]
        public void ThenICanResizeTheWidgetWithNameOnTheDashboardItemPage(string widgetName, int widthValue, int heightValue)
        {
            var widgetWidthBeforeResize = _dashboardsContext.GetWidgetWidth(widgetName);
            var widgetHeightBeforeResize = _dashboardsContext.GetWidgetHeight(widgetName);
            _dashboardsContext.ResizeWidget(widgetName, widthValue, heightValue);

            Assert.AreEqual(_dashboardsContext.GetWidgetWidth(widgetName), widgetWidthBeforeResize + widthValue);
            Assert.AreEqual(_dashboardsContext.GetWidgetHeight(widgetName), widgetHeightBeforeResize + heightValue);
        }

        [Then(@"I can drag and drop the widget with '(.*)' name using '(.*)' position X and '(.*)' position Y on the Dashboard Item page")]
        public void ThenICanDragAndDropTheWidgetWithNameOnTheDashboardItemPage(string widgetName, int positionXValue, int positionYValue)
        {
            var widgetPositionXBeforeDragAndDrop = _dashboardsContext.GetWidgetTransformPositionX(widgetName);
            var widgetPositionYBeforeDragAndDrop = _dashboardsContext.GetWidgetTransformPositionY(widgetName);
            _dashboardsContext.DragAndDropWidget(widgetName, positionXValue, positionYValue);

            Assert.AreEqual(_dashboardsContext.GetWidgetTransformPositionX(widgetName), widgetPositionXBeforeDragAndDrop + positionXValue);
            Assert.AreEqual(_dashboardsContext.GetWidgetTransformPositionY(widgetName), widgetPositionYBeforeDragAndDrop + positionYValue);
        }
    }
}
