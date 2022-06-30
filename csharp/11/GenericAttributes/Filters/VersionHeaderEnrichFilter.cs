namespace GenericAttributes.Filters;

public class VersionHeaderEnrichFilter : BaseHeaderEnrichFilter
{
    public VersionHeaderEnrichFilter() 
        : base("Version", "2.0")
    {
    }
}