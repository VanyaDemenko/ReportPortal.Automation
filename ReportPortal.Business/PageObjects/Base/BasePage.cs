using OpenQA.Selenium;
using ReportPortal.Business.Components.BaseComponents;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Interfaces.PageObjects;

namespace ReportPortal.Business.PageObjects.Base
{
    public abstract class BasePage : Container, IPage
    {
        public BaseLabel NotificationMessage => Select<BaseLabel>(By.XPath("//div[contains(@class, 'notificationList')]"));

        public virtual void WaitForReadyState()
        {
            DriverHelper.WaitPageFullLoaded();
        }
    }
}
