using System.Reflection;
using OpenQA.Selenium;
using ReportPortal.Business.Drivers;
using ReportPortal.Business.Interfaces.PageObjects;
using ReportPortal.Core.Utils.Attributes;

namespace ReportPortal.Business.PageObjects.Base
{
    public abstract class Container : IContainer
    {
        private IWebDriver? _driver;
        private IWebElement? _relatedElement;

        public IWebElement Element
        {
            get => _relatedElement ??= Driver.FindElement(By.CssSelector("body"));
            set => _relatedElement = value;
        }

        public IWebDriver Driver
        {
            get => _driver ??= ((IWrapsDriver)Element).WrappedDriver;
            set => _driver = value;
        }

        public T Select<T>(By selector) where T : Container, new()
        {
            return new T()
            {
                Element = DriverProvider.Wait.Until(el => Element.FindElement(selector))
            };
        }

        public IEnumerable<T> SelectAll<T>(By selector) where T : Container, new()
        {
            var elements = DriverProvider.Wait.Until(elem => Element.FindElements(selector));
            return elements.Select(e => new T
            {
                Element = e
            });
        }

        public virtual T GetComponent<T>(string name) where T : Container
        {
            List<T> controls = new List<T>();
            IEnumerable<MemberInfo> membersInfo = ((IEnumerable<MemberInfo>)this.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<MemberInfo>((Func<MemberInfo, bool>)(info => (info.MemberType == MemberTypes.Property || info.MemberType == MemberTypes.Field) && info.GetCustomAttributes().Any<Attribute>((Func<Attribute, bool>)(attribute => attribute is TitlesAttribute))));
            return this.GetMemberWithTitle<T>(name, controls, membersInfo);
        }

        protected virtual T GetMemberWithTitle<T>(
            string title,
            List<T> controls,
            IEnumerable<MemberInfo> membersInfo)
            where T : Container
        {
            foreach (MemberInfo element in membersInfo)
            {
                TitlesAttribute customAttribute = element.GetCustomAttribute<TitlesAttribute>()!;
                if (customAttribute != null && customAttribute.Titles.Contains(title))
                {
                    if ((object)(element as FieldInfo) != null)
                        controls.Add(((FieldInfo)element).GetValue((object)this) as T);
                    else if ((object)(element as PropertyInfo) != null)
                        controls.Add(((PropertyInfo)element).GetValue((object)this) as T);
                }
            }
            if (controls.Count == 0)
                throw new Exception(string.Format("No '{0}' control found. Please check '{1}' definition.", (object)title, (object)this.GetType()));
            return controls.Count <= 1 ? controls[0] : throw new Exception(string.Format("Multiple '{0}' controls found. Please check '{1}' definition.", (object)title, (object)this.GetType()));
        }
    }
}
