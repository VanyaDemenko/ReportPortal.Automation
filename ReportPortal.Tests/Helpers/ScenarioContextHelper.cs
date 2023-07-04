using TechTalk.SpecFlow;

namespace ReportPortal.Tests.Helpers
{
    public static class ScenarioContextHelper
    {
        public static T? GetFromContext<T>(this ScenarioContext scenarioContext, string key)
        {
            return scenarioContext.TryGetValue(key, out T value) ? value : default;
        }
    }
}
