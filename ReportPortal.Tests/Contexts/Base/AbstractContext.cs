using ReportPortal.Business.Drivers;
using ReportPortal.Business.Factories;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Tests.Contexts.Base
{
    public abstract class AbstractContext<TPage> : IContext where TPage : BasePage, new()
    {
        protected TPage Page { get; }

        protected AbstractContext()
        {
            Page = EntryPageFactory.Create<TPage>(DriverProvider.Driver);
        }
    }
}
