using Microsoft.AspNetCore.Mvc.Filters;

namespace GenericAttributes.Filters;

public class ResponseHeadersEnrichFilterAttribute<T> : Attribute, IFilterFactory 
    where T : BaseHeaderEnrichFilter
{
    public bool IsReusable { get; }
    
    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        if (serviceProvider == null)
            throw new ArgumentNullException(nameof(serviceProvider));

        var filter = (IFilterMetadata)serviceProvider.GetRequiredService<T>();
        
        if (filter is IFilterFactory filterFactory) 
            filter = filterFactory.CreateInstance(serviceProvider);

        return filter;
    }
}