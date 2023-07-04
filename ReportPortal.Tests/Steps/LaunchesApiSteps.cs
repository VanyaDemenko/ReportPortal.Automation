using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Structures.DataModels.Requests;
using ReportPortal.Business.Structures.DataModels.Responses;
using ReportPortal.Business.Structures.Entities;
using ReportPortal.Tests.Contexts;
using ReportPortal.Tests.Helpers;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    internal class LaunchesApiSteps
    {
        private readonly LaunchesApiContext _launchesApiContext = new();
        private readonly ScenarioContext _scenarioContext;

        public LaunchesApiSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I try to get a list of launches from '(.*)' project using '(.*)' user")]
        public void WhenITryToGetListOfLaunchesFromProjectForUser(string projectName, UserEntity user)
        {
            var response = _launchesApiContext.GetListOfLaunchesFromProjectUsingUser(projectName, user.Token!);
            _scenarioContext.Set(response, "LastApiResponse");
        }

        [When(@"I try to create a launch for '(.*)' project using '(.*)' user:")]
        public void WhenITryToCreateALaunchForProjectUsingUser(string projectName, UserEntity user, AddLaunchDTO launchInfo)
        {
            var response = _launchesApiContext.CreateLaunchForProjectUsingUser(projectName, user.Token!, launchInfo);
            _scenarioContext.Set(response, "LastApiResponse");
        }

        [When(@"I try to get info for launch with '(.*)' id for '(.*)' project using '(.*)' user")]
        public void WhenITryToGetInfoForLaunchWithIdForProjectUsingUser(string variableName, string projectName, UserEntity user)
        {
            var launchId = _scenarioContext.GetFromContext<long>(variableName);
            if (launchId == 0) launchId = long.Parse(variableName);

            var response = _launchesApiContext.GetLaunchFromProjectUsingUser(launchId, projectName, user.Token!);
            _scenarioContext.Set(response, "LastApiResponse");
        }

        [When(@"I remember id of newly added launch for '(.*)' project as '(.*)' variable using '(.*)' user")]
        public void WhenIRememberIdOfNewlyAddedLaunchForProjectUsingUser(string projectName, string variableName, UserEntity user)
        {
            var uuid = _scenarioContext.Get<ApiResponseExtensions>("LastApiResponse").GetContent<AddLaunchResponseDTO>().Id;
            var response = _launchesApiContext.GetListOfLaunchesFromProjectUsingUser(projectName, user.Token!);
            var id = response.GetContent<LaunchesListResponseDTO>().Content.First(launch => launch.Uuid.Equals(uuid)).Id;
            _scenarioContext.Set(id, variableName);
        }

        [When(@"I stop the launch with '(.*)' id for '(.*)' project using '(.*)' user:")]
        public void WhenIStopTheLaunchWithIdForProjectUsingUser(string variableName, string projectName, UserEntity user, StopLaunchDTO launchInfo)
        {
            var launchId = _scenarioContext.GetFromContext<long>(variableName);
            if (launchId == 0) launchId = long.Parse(variableName);

            var response = _launchesApiContext.StopLaunchForProjectUsingUser(launchId, projectName, user.Token!, launchInfo);
            _scenarioContext.Set(response, "LastApiResponse");
        }

        [When(@"I delete the launch with '(.*)' id for '(.*)' project using '(.*)' user")]
        public void WhenIDeleteTheLaunchWithIdForProjectUsingUser(string variableName, string projectName, UserEntity user)
        {
            var launchId = _scenarioContext.GetFromContext<long>(variableName);
            if (launchId == 0) launchId = long.Parse(variableName);

            var response = _launchesApiContext.DeleteLaunchFromProjectUsingUser(launchId, projectName, user.Token!);
            _scenarioContext.Set(response, "LastApiResponse");
        }

        /* Actions Validation */

        [Then(@"I should get a valid list of launches")]
        public void ThenIShouldGetValidListOfLaunches()
        {
            var response = _scenarioContext.Get<ApiResponseExtensions>("LastApiResponse");
            var launchesList = response.GetContent<LaunchesListResponseDTO>();
            launchesList.Should().NotBeNull();
            launchesList.Content.Should().NotBeNullOrEmpty();
        }

        [Then(@"I verify that the launch with '(.*)' id for '(.*)' project (contains|doesn't contain) data using '(.*)' user:")]
        public void ThenLaunchForProjectContainsData(string variableName, string projectName, bool expectedState, UserEntity user, List<Dictionary<string, string>> propertiesToVerify)
        {
            var launchId = _scenarioContext.GetFromContext<long>(variableName);
            if (launchId == 0) launchId = long.Parse(variableName);
            
            var response = _launchesApiContext.GetLaunchFromProjectUsingUser(launchId, projectName, user.Token!);
            var launch = response.GetContent<LaunchResponseDTO>();

            if (expectedState) launch.PropertiesShouldContainEquivalent(propertiesToVerify);
            else launch.PropertiesShouldNotContainEquivalent(propertiesToVerify);
        }

        [Then(@"I verify that list of launches (contains|doesn't contain) launch with '(.*)' id for '(.*)' project using '(.*)' user")]
        public void ThenIVerifyThatListOfLaunchesLaunchWithIdForProjectUsingUser(bool expectedState, string variableName, string projectName, UserEntity user)
        {
            var launchId = _scenarioContext.GetFromContext<long>(variableName);
            if (launchId == 0) launchId = long.Parse(variableName);

            var response = _launchesApiContext.GetListOfLaunchesFromProjectUsingUser(projectName, user.Token!);
            var launchIds = response.GetContent<LaunchesListResponseDTO>().Content.Select(launch => launch.Id);

            if (expectedState) launchIds.Should().Contain(launchId);
            else launchIds.Should().NotContain(launchId);
        }
    }
}
