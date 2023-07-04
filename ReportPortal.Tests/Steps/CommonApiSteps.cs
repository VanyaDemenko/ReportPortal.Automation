using FluentAssertions;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Structures.DataModels.Responses;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Steps
{
    [Binding]
    public class CommonApiSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonApiSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"I should get a response with '(\d+)' status code")]
        public void ThenIShouldGetAResponseWithStatusCode(int expectedStatusCode)
        {
            var response = _scenarioContext.Get<ApiResponseExtensions>("LastApiResponse");
            var actualStatusCode = (int)response.StatusCode;

            actualStatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"I should get an error response with data:")]
        public void ThenIShouldGetErrorResponseWithData(ErrorResponseDTO expectedErrorInfo)
        {
            var response = _scenarioContext.Get<ApiResponseExtensions>("LastApiResponse");
            var actualErrorInfo = response.GetContent<ErrorResponseDTO>();
            actualErrorInfo.Message = actualErrorInfo.Message.Trim();
            
            actualErrorInfo.Should().BeEquivalentTo(expectedErrorInfo);
        }

    }
}
