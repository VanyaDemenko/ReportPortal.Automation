using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Base.BaseReportPortalPage.FooterSection
{
    public class FooterContainer : Container
    {
        [Titles("Build Number")]
        public BaseLabel BuildNumber => Select<BaseLabel>(By.XPath(".//div[contains(@class, 'footer__footer-text')][1]"));
    }
}
