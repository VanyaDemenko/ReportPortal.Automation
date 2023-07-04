using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Extensions;
using ReportPortal.Core.Enums;
using ReportPortal.Tests.Helpers;
using Serilog;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace ReportPortal.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        [BeforeScenario]
        public void UpdateTestCaseStatusBeforeRunScenario(ScenarioContext context)
        {
            JiraService.UpdateTestCaseStatus("In Test", context);
        }

        [BeforeScenario("@UI")]
        public void BeforeScenario()
        {
            DriverProvider.StartBrowser(EnumExtensions.GetEnumByDescription<BrowserTypeEnum>(DataProvider.GetBrowserType()));
            DriverProvider.Driver.Navigate().GoToUrl(DataProvider.GetApplicationUrl());
            DriverHelper.WaitPageFullLoaded();
        }

        [AfterScenario]
        public void UpdateTestCaseStatusAfterRunScenario(ScenarioContext context)
        {
            var result = context.TestError == null ? "Passed" : "Failed";
            JiraService.UpdateTestCaseStatus(result, context);
        }

        [AfterScenario("@UI")]
        public void AfterScenario()
        {
            DriverProvider.StopBrowser();
        }

        [AfterStep("@UI")]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null) return;
            var content = CaptureScreenShot();
            AllureLifecycle.Instance.AddAttachment("ScreenShot of Failed scenario", "application/png", content);
        }

        private byte[] CaptureScreenShot() => ((ITakesScreenshot)DriverProvider.Driver).GetScreenshot().AsByteArray;
    }
}
