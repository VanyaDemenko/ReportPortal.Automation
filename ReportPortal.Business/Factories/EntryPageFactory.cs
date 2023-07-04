using OpenQA.Selenium;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.Factories
{
    public static class EntryPageFactory
    {
        public static TPage Create<TPage>(IWebDriver driver) where TPage : BasePage, new()
        {
            return new TPage()
            {
                Driver = driver
            };
        }
    }
}
