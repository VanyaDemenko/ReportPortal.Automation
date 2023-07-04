using ReportPortal.Tests.Contexts;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly CommonContext _commonContext = new();

        [When(@"I logout from ReportPortal")]
        public void WhenILogoutFromReportPortal()
        {
            _commonContext.LogOutFromReportPortal();
        }

        [When(@"I select '(.*)' navigation menu option")]
        public void WhenISelectNavigationMenuOption(string menuOption)
        {
            _commonContext.SelectNavigationMenuOption(menuOption);
        }
    }
}
