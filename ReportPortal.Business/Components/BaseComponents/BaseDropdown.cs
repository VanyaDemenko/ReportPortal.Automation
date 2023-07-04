using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.Interfaces.Components;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.Components.BaseComponents
{
    public class BaseDropdown : Container, IGetValue, ISetValue, IDropdown
    {
        public IWebElement Dropdown => DriverProvider.Driver.FindElement(By.XPath("//div[contains(@class, 'Block__menu--')]"));

        public IEnumerable<IWebElement> DropdownOptions 
            => DriverProvider.Driver.FindElements(By.XPath("//div[contains(@class, 'Block__menu--')]//*[contains(@class, 'menu-item')]"));

        public IWebElement GetOption(string option)
            => DropdownOptions.First(name => name.GetInnerText().Equals(option));

        public string GetValue()
        {
            return Element.GetAttribute("innerText");
        }

        public void SetValue(string value)
        {
            Open();
            SelectOption(value);
        }

        public List<string> GetOptions()
        {
            Open();
            List<string> options = new();
            DropdownOptions.ToList().ForEach(option => options.Add(option.GetInnerText()));
            return options;
        }

        public void Open()
        {
            Element.Click();
            Dropdown.WaitForElementToDisplayed();
        }

        public void SelectOption(string option)
        {
            GetOption(option).Click();
        }
    }
}
