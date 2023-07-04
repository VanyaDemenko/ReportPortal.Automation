using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Pages.Launches.LaunchesDataTable
{
    public class LaunchesTableRow : Container
    {
        [Titles("Name")]
        public BaseLabel Name => Select<BaseLabel>(By.XPath(".//td//div[@class = 'itemInfo__main-info--2HB9g']"));

        [Titles("Description")]
        public BaseLabel Description => Select<BaseLabel>(By.XPath(".//tr//div[contains(@class, 'markdown-viewer')]//h3"));

        [Titles("Total")]
        public BaseLabel Total => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'total-col')]"));

        [Titles("Passed")]
        public BaseLabel Passed => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'passed-col')]"));

        [Titles("Failed")]
        public BaseLabel Failed => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'failed-col')]"));

        [Titles("Skipped")]
        public BaseLabel Skipped => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'skipped-col')]"));

        [Titles("Product Bug")]
        public BaseLabel ProductBug => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'pb-col')]"));

        [Titles("Auto Bug")]
        public BaseLabel AutoBug => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'ab-col')]"));

        [Titles("System Issue")]
        public BaseLabel SystemIssue => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'si-col')]"));

        [Titles("To Investigate")]
        public BaseLabel ToInvestigate => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'ti-col')]"));
    }
}
