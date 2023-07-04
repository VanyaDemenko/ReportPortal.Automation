using ReportPortal.Tests.Contexts.Base;
using ReportPortal.Core.Enums;
using ReportPortal.Business.Extensions;
using ReportPortal.Business.PageObjects.Base;
using System;
using ReportPortal.Business.Interfaces.Components;

namespace ReportPortal.Tests.Contexts
{
    public class ComponentContext<TPage> : AbstractContext<TPage> where TPage : BasePage, new()
    {
        public void ClickComponentAtTheContainer(string componentName, string containerName)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            baseContainer.GetContainerByTitle(componentName).Element.Click();
            Page.WaitForReadyState();
        }

        public void SetValue(string value, string componentToSetName, string containerName)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            (baseContainer.GetContainerByTitle(componentToSetName) as ISetValue)!.SetValue(value);
            Page.WaitForReadyState();
        }

        public string GetValue(string componentToSetName, string containerName)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            return (baseContainer.GetContainerByTitle(componentToSetName) as IGetValue)!.GetValue();
        }

        public bool GetControlStateAtTheContainer(string componentName, string containerName, ElementState stateCriteria)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            var nestedContainer = baseContainer.GetContainerByTitle(componentName);

            return stateCriteria switch
            {
                ElementState.Displayed => nestedContainer.Element.IsDisplayed(),
                ElementState.Enabled => nestedContainer.Element.IsEnabled(),
                ElementState.Exists => nestedContainer.Element.IsExist(),
                _ => throw new ArgumentException($"Incorrect state criteria for {componentName}: {stateCriteria}")
            };
        }

        public bool GetContainerState(string containerName, ElementState stateCriteria)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);

            return stateCriteria switch
            {
                ElementState.Displayed => baseContainer.Element.IsDisplayed(),
                ElementState.Enabled => baseContainer.Element.IsEnabled(),
                ElementState.Exists => baseContainer.Element.IsExist(),
                _ => throw new ArgumentException($"Incorrect state criteria for {containerName}: {stateCriteria}")
            };
        }

        public void ScrollToComponentAtTheContainer(string componentName, string containerName)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            baseContainer.GetContainerByTitle(componentName).Element.ScrollToElementByJs();
            Page.WaitForReadyState();
        }

        public bool IsComponentAtTheContainerScrolledIntoView(string componentName, string containerName)
        {
            var baseContainer = Page.GetContainerByTitle(containerName);
            return baseContainer.GetContainerByTitle(componentName).Element.IsScrolledIntoViewByJs();
        }
    }
}
