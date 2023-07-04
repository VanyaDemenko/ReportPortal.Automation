using ReportPortal.Business.ApiFacade;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Structures.DataModels.Requests;
using ReportPortal.Tests.Contexts.Base;

namespace ReportPortal.Tests.Contexts
{
    public class LaunchesApiContext : IContext
    {
        public ApiResponseExtensions GetListOfLaunchesFromProjectUsingUser(string projectName, string authorizationToken)
        {
            return new ReportPortalApi(authorizationToken).GetLaunchesListForProject(projectName);
        }

        public ApiResponseExtensions GetLaunchFromProjectUsingUser(long launchId, string projectName, string authorizationToken)
        {
            return new ReportPortalApi(authorizationToken).GetLaunchForProject(launchId, projectName);
        }

        public ApiResponseExtensions CreateLaunchForProjectUsingUser(string projectName, string authorizationToken, AddLaunchDTO launchInfo)
        {
            return new ReportPortalApi(authorizationToken).CreateLaunchForProject(projectName, launchInfo);
        }

        public ApiResponseExtensions StopLaunchForProjectUsingUser(long launchId, string projectName, string authorizationToken, StopLaunchDTO launchInfo)
        {
            return new ReportPortalApi(authorizationToken).StopLaunchForProject(launchId, projectName, launchInfo);
        }

        public ApiResponseExtensions DeleteLaunchFromProjectUsingUser(long launchId, string projectName, string authorizationToken)
        {
            return new ReportPortalApi(authorizationToken).DeleteLaunchFromProject(launchId, projectName);
        }
    }
}
