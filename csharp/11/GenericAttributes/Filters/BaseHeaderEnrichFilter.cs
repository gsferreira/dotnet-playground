using Microsoft.AspNetCore.Mvc.Filters;

namespace GenericAttributes.Filters;

public abstract class BaseHeaderEnrichFilter : IActionFilter
{
    private readonly string _name;
    private readonly string _value;

    protected BaseHeaderEnrichFilter(string name, string value)
    {
        _name = name;
        _value = value;
    }
    
    public void OnActionExecuting(ActionExecutingContext context) =>
        context.HttpContext.Response.Headers.Add(
            _name, _value);

    public void OnActionExecuted(ActionExecutedContext context) { }
    
}