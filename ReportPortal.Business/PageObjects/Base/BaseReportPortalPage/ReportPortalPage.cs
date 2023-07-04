using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage.FooterSection;
using ReportPortal.Business.PageObjects.Base.BaseReportPortalPage.NavigationMenu;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Base.BaseReportPortalPage
{
    public class ReportPortalPage : BasePage
    {
        public NavMenuOptionsContainer NavMenuOptionsContainer => Select<NavMenuOptionsContainer>(By.XPath("//div[contains(@class, 'sidebar__top-block')]"));

        [Titles("Footer")]
        public FooterContainer FooterContainer => Select<FooterContainer>(By.XPath("//footer"));

        public BaseDropdown AccountDropdown => Select<BaseDropdown>(By.XPath("//div[contains(@class, 'userBlock')]"));

        public void SelectNavMenuOption(string menuOption) => NavMenuOptionsContainer.GetComponent<Container>(menuOption).Element.Click();

        public void LogOut() => AccountDropdown.SetValue("LOGOUT");
    }
}
