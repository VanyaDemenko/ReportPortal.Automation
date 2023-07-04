using NUnit.Framework;
using ReportPortal.Tests.Contexts;
using ReportPortal.Core.Enums;
using ReportPortal.Business.PageObjects.Pages.Login;
using ReportPortal.Business.Structures.Entities;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginContext _loginContext = new();
        private readonly ComponentContext<LoginPage> _componentContext = new();

        [Given(@"I login as a '(.*)' user to ReportPortal")]
        public void GivenILoginAsAUser(UserEntity user)
        {
            _loginContext.LoginToReportPortal(user.Login!, user.Password!);
        }

        [Then(@"'(.*)' control (is|is not) '(.*)' on the Login page")]
        public void ThenControlIsOnTheLoginPage(string controlName, bool expectedState, ElementState stateToCheck)
        {
            var actualState = _componentContext.GetContainerState(controlName, stateToCheck);
            Assert.AreEqual(expectedState, actualState);
        }
    }
}
