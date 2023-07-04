using ReportPortal.Business.PageObjects.Base;

namespace ReportPortal.Business.Extensions
{
    public static class ContainerExtensions
    {
        public static Container GetContainerByTitle(this Container container, string title)
        {
            Container neededContainer;
            try
            {
                neededContainer = container.GetComponent<Container>(title);
                return neededContainer ?? null!;
            }
            catch (Exception)
            {
                List<Container> containerList = new List<Container>();
                container.GetType().GetProperties().Where(p => p.PropertyType.BaseType == typeof(Container)).ToList()
                    .ForEach(x => containerList.Add(x.GetValue(container) as Container));
                foreach (var cont in containerList)
                {
                    neededContainer = cont.GetContainerByTitle(title);
                    if (neededContainer != null) return neededContainer;
                }
                return null!;
            }
        }
    }
}
