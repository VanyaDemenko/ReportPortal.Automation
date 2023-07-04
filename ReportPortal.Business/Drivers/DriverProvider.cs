using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using ReportPortal.Core.DataConstants;
using ReportPortal.Core.Enums;

namespace ReportPortal.Business.Drivers
{
    public static class DriverProvider
    {
        private static readonly ThreadLocal<IWebDriver> _instance = new();
        private static readonly ThreadLocal<WebDriverWait> _browserWait = new();

        public static IWebDriver Driver
        {
            get
            {
                if (_instance == null) throw new NullReferenceException("The WebDriver browser instance was not initialized.");
                return _instance.Value;
            }
            private set => _instance.Value = value;
        }

        public static WebDriverWait Wait
        {
            get
            {
                if (_browserWait == null) throw new NullReferenceException("The WebDriver browser wait instance was not initialized.");
                return _browserWait.Value;
            }
            private set => _browserWait.Value = value;
        }

        public static void StartBrowser(BrowserTypeEnum browserType)
        {
            Driver = browserType switch
            {
                BrowserTypeEnum.Chrome => new ChromeDriver(GetChromeOptions()),
                BrowserTypeEnum.RemoteChrome => new RemoteWebDriver(new Uri(RemoteBrowsersConstance.SelenoidBaseUrl), GetChromeOptions()),
                BrowserTypeEnum.RemoteFirefox => new RemoteWebDriver(new Uri(RemoteBrowsersConstance.SelenoidBaseUrl), GetFirefoxOptions()),
                BrowserTypeEnum.RemoteSauceLabsChrome => new RemoteWebDriver(new Uri(RemoteBrowsersConstance.SauceLabsBaseUrl), GetSauceLabsChromeOptions()),
                _ => throw new ArgumentException("You need to set a valid browser type in the appconfig.json file.")
            };

            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOutConstants.SearchConfigurationTimeout));
        }

        public static void StopBrowser()
        {
            Driver.Quit();
            Driver = null!;
            Wait = null!;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-notifications");
            return chromeOptions;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions remoteFirefoxOptions = new();
            remoteFirefoxOptions.AddArgument("--start-maximized");
            remoteFirefoxOptions.AddArgument("--disable-notifications");
            return remoteFirefoxOptions;
        }

        private static ChromeOptions GetSauceLabsChromeOptions()
        {
            ChromeOptions remoteChromeOptionsSauceLabs = new();
            remoteChromeOptionsSauceLabs.AddArgument("--start-maximized");
            remoteChromeOptionsSauceLabs.AddArgument("--disable-notifications");
            remoteChromeOptionsSauceLabs.PlatformName = "Windows 11";
            remoteChromeOptionsSauceLabs.BrowserVersion = "latest";
            var sauceOptions = new Dictionary<string, object>
            {
                { "username", RemoteBrowsersConstance.SauceLabsUserName },
                { "accessKey", RemoteBrowsersConstance.SauceLabsAccessKey },
                { "build", "selenium-build-WICGL" },
                { "name", "Test Run" }
            };
            remoteChromeOptionsSauceLabs.AddAdditionalOption("sauce:options", sauceOptions);
            return remoteChromeOptionsSauceLabs;
        }
    }
}
