using ReportPortal.Business.Interfaces.Components;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.Components.BaseComponents
{
    public class BaseLabel : Container, IGetValue
    {
        public virtual string GetValue()
        {
            return Element.GetAttribute("innerText");
        }
    }
}
