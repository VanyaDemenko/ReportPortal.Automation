using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Base.BaseReportPortalPage.NavigationMenu
{
    public class NavMenuOptionsContainer : Container
    {
        [Titles("Dashboards")]
        public BaseButton Dashboards => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Dashboards']]"));

        [Titles("Launches")]
        public BaseButton Launches => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Launches']]"));

        [Titles("Filters")]
        public BaseButton Filters => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Filters']]"));

        [Titles("Debug")]
        public BaseButton Debug => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Debug']]"));

        [Titles("Project members")]
        public BaseButton ProjectMembers => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Project members']]"));

        [Titles("Project settings")]
        public BaseButton ProjectSettings => Select<BaseButton>(By.XPath("./div[.//span[text() = 'Project settings']]"));
    }
}
