using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ReportPortal.Tests.Contexts;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    public class LaunchesSteps
    {
        private readonly LaunchesContext _launchesContext = new();

        [Then(@"Launch with '(.*)' name has data:")]
        public void ThenLaunchWithNameHasData(string launchName, List<Dictionary<string, string>> valuesToCheck)
        {
            foreach (var (fieldName, expectedValue) in valuesToCheck.Single())
            {
                var actualValue = _launchesContext.GetControlDataFromLaunchWithName(fieldName, launchName);
                actualValue.Should().Be(expectedValue);
            }
        }
    }
}