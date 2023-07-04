using ReportPortal.Business.Extensions;
using ReportPortal.Business.Interfaces.Components;
using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.Components.BaseComponents
{
    public class BaseTextField : Container, ISetValue, IGetValue
    {
        public virtual void SetValue(string value)
        {
            Element.SetValueAndFocusOut(value);
        }

        public virtual string GetValue()
        {
            return Element.GetAttribute("value");
        }
    }
}
