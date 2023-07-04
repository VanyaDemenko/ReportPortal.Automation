namespace ReportPortal.Core.Utils.Attributes
{
    public class TitlesAttribute : Attribute
    {
        public TitlesAttribute(params string[] titles) => this.Titles = ((IEnumerable<string>)titles).ToList<string>();

        public List<string> Titles { get; private set; }
    }
}
