using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ReportPortal.Business.Drivers;
using SeleniumExtras.WaitHelpers;

namespace ReportPortal.Business.Extensions
{
    public static class ElementExtensions
    {
        public static bool IsExist(this IWebElement element)
        {
            return element != null;
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            return element.Displayed;
        }

        public static bool IsEnabled(this IWebElement element)
        {
            return element.Enabled;
        }

        public static bool IsExistsAndDisplayed(this IWebElement element)
        {
            return element.IsExist() && element.IsDisplayed();
        }

        public static void WaitForElementToDisplayed(this IWebElement element)
        {
            DriverProvider.Wait.Until((x) => element.IsDisplayed());
        }

        public static void WaitForElementToNotDisplayed(this IWebElement element)
        {
            DriverProvider.Wait.Until((x) => !element.IsDisplayed());
        }

        public static void WaitForElementBeClickable(this IWebElement element)
        {
            element.WaitForElementToDisplayed();
            DriverProvider.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void ClickWithJavaScript(this IWebElement element)
        {
            ((IJavaScriptExecutor)DriverProvider.Driver).ExecuteScript("arguments[0].click();", element);
        }

        public static void RightClick(this IWebElement element)
        {
            new Actions(DriverProvider.Driver).ContextClick(element).Build().Perform();
        }

        public static void ScrollToElement(this IWebElement element)
        {
            new Actions(DriverProvider.Driver).MoveToElement(element).Build().Perform();
            element.WaitForElementBeClickable();
        }

        public static void ScrollToElementByJs(this IWebElement element)
        {
            ((IJavaScriptExecutor)DriverProvider.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static bool IsScrolledIntoViewByJs(this IWebElement element)
        {
            return (bool)((IJavaScriptExecutor)DriverProvider.Driver).ExecuteScript(@"
                var element = arguments[0];
                var rect = element.getBoundingClientRect();
                return (rect.top >= 0 && rect.left >= 0 && rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && rect.right <= (window.innerWidth || document.documentElement.clientWidth));",
                element);
        }

        public static void HoverOverElement(this IWebElement element)
        {
            new Actions(DriverProvider.Driver).MoveToElement(element).Perform();
        }

        public static void FocusOut(this IWebElement element)
            => DriverProvider.Driver.FindElement(By.XPath("//html")).Click();

        private static void SetValue(this IWebElement element, string value)
        {
            value ??= string.Empty;
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(value);
        }

        public static void SetValueAndFocusOut(this IWebElement element, string value)
        {
            element.SetValue(value);
            FocusOut(element);
        }

        public static void SetValueAndClickEscape(this IWebElement element, string value)
        {
            element.SetValue(value);
            element.SendKeys(Keys.Escape);
        }

        public static void SetValueAndTabOut(this IWebElement element, string value)
        {
            element.SetValue(value);
            element.SendKeys(Keys.Tab);
        }

        public static void SetValueAndClickEnter(this IWebElement element, string value)
        {
            element.SetValue(value);
            element.SendKeys(Keys.Enter);
        }

        public static void DragAndDrop(this IWebElement element, int offsetX, int offsetY)
        {
            new Actions(DriverProvider.Driver).DragAndDropToOffset(element, offsetX, offsetY).Perform();
        }

        public static void Resize(this IWebElement element, int offsetX, int offsetY)
        {
            new Actions(DriverProvider.Driver).ClickAndHold(element).MoveByOffset(offsetX, offsetY).Release().Perform();
        }

        public static string GetInnerText(this IWebElement element) => element.GetAttribute("innerText");

        public static string GetBackgroundColor(this IWebElement element) => element.GetCssValue("background-color");

        public static string GetColor(this IWebElement element) => element.GetCssValue("color");

        public static int GetHeight(this IWebElement element) => int.Parse(element.GetCssValue("height").Replace("px", ""));

        public static int GetWidth(this IWebElement element) => int.Parse(element.GetCssValue("width").Replace("px", ""));

        public static int GetTransformPositionX(this IWebElement element)
        {
            var value = element.GetCssValue("transform");
            var matches = Regex.Matches(value, @"\d+");
            return int.Parse(matches[4].Value);
        }

        public static int GetTransformPositionY(this IWebElement element)
        {
            var value = element.GetCssValue("transform");
            var matches = Regex.Matches(value, @"\d+");
            return int.Parse(matches[5].Value);
        }
    }
}
