using airport_api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace airport_api.Filters;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;
    
        public void OnActionExecuting(ActionExecutingContext context) { }
    
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                var value = JsonConvert.SerializeObject(new { message = httpResponseException.Message });
                context.Result = new ObjectResult(value)
                {
                    StatusCode = (int)httpResponseException.StatusCode,
                };
                
                context.ExceptionHandled = true;
            }
        }
}