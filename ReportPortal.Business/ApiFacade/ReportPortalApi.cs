using Newtonsoft.Json;
using ReportPortal.Business.Builders;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Structures.DataModels.Requests;
using ReportPortal.Core.DataConstants;
using RestSharp;

namespace ReportPortal.Business.ApiFacade
{
    public class ReportPortalApi
    {
        public RequestBuilder request;
        public ReportPortalApi(string authorizationToken)
        {
            request = new RequestBuilder(BaseApiConstance.BaseUrl, authorizationToken);
        }

        public ApiResponseExtensions GetLaunchesListForProject(string projectName)
        {
            var url = $"{projectName}/launch";
            return request.Method(Method.Get).Uri(url).Execute();
        }

        public ApiResponseExtensions GetLaunchForProject(long launchId, string projectName)
        {
            var url = $"{projectName}/launch/{launchId}";
            return request.Method(Method.Get).Uri(url).Execute();
        }

        public ApiResponseExtensions CreateLaunchForProject(string projectName, AddLaunchDTO launchInfo)
        {
            var url = $"{projectName}/launch";
            var requestBody = JsonConvert.SerializeObject(launchInfo);
            return request.Method(Method.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponseExtensions StopLaunchForProject(long launchId, string projectName, StopLaunchDTO launchInfo)
        {
            var url = $"{projectName}/launch/{launchId}/stop";
            var requestBody = JsonConvert.SerializeObject(launchInfo);
            return request.Method(Method.Put).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponseExtensions DeleteLaunchFromProject(long launchId, string projectName)
        {
            var url = $"{projectName}/launch/{launchId}";
            return request.Method(Method.Delete).Uri(url).Execute();
        }
    }
}
