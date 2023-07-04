using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReportPortal.Business.Structures.DataModels.Requests.Jira;
using ReportPortal.Core.DataConstants;
using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Helpers
{
    public static class JiraService
    {
        private const string IssueUrlTemplate = "{0}/rest/api/latest/issue/{1}";
        private const string IssueFieldsUpdateTemplate = IssueUrlTemplate + "/transitions?expand=transitions.field";
        private static readonly byte[] AuthToken = Encoding.GetEncoding("ISO-8859-1").GetBytes(JiraConstance.UserName + ":" + JiraConstance.Password);
        
        public static async void UpdateTestCaseStatus(string status, ScenarioContext context)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(AuthToken));

            var body = new
            {
                transition = new
                {
                    id = GetTestCaseStatusIdFromJira(status, context).Result
                }
            };

            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(string.Format(IssueFieldsUpdateTemplate, JiraConstance.BaseUrl, GetTestCaseId(context)), data);
            response.EnsureSuccessStatusCode();
        }

        private static async Task<string> GetTestCaseStatusIdFromJira(string status, ScenarioContext context)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(AuthToken));

            var response = await client.GetAsync(string.Format(IssueFieldsUpdateTemplate, JiraConstance.BaseUrl, GetTestCaseId(context)));
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var statusId = JsonConvert.DeserializeObject<TestCaseModel>(resp).Transitions
                .FirstOrDefault(transition => transition.Name.Equals(status))?.Id;
            return statusId;
        }

        public static string GetTestCaseId(ScenarioContext context) => context.ScenarioInfo.Tags.First(tag => tag.StartsWith("RP"));
    }
}
