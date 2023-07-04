using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.PageObjects.Pages.Dashboards.DashboardsDataTable
{
    public class DashboardsTableRow : Container
    {
        public BaseLabel Name => Select<BaseLabel>(By.XPath(".//a"));

        public BaseLabel Description => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'description')]"));

        public BaseLabel Owner => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'owner')]"));

        public BaseButton Shared => Select<BaseButton>(By.XPath(".//div/i[contains(@class, 'check')]"));

        public BaseButton EditButton => Select<BaseButton>(By.XPath(".//div/i[contains(@class, 'pencil')]"));
        
        public BaseButton DeleteButton => Select<BaseButton>(By.XPath(".//div/i[contains(@class, 'delete')]"));
    }
}
