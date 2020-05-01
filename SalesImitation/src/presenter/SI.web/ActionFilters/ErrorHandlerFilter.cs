using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SI.Common.Models;
using SI.Domain.Exceptions;
using System.Threading.Tasks;
using SI.Common.Abstractions;

namespace SI.Web.ActionFilters
{
    public class ErrorHandlerFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;
        public ErrorHandlerFilter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            if (result.Exception != null)
            {
                _logger.Error("ErrorHandlerFilter.OnActionExecutionAsync",result.Exception);
                string errorText = string.Empty;
                if (result.Exception is LocalizableException)
                {
                    var ex = result.Exception as LocalizableException;
                    errorText = ex.MessageKey;
                    // errorText = _sharedLocalizer[ex.MessageKey]?.Value;
                }
                else
                    errorText = "მოხდა გაუთვალისწინებელი შეცდომა";
                    // errorText = _sharedLocalizer["unexpected"]?.Value;

                result.ExceptionHandled = true;
                Result resultObj = new Result(false, errorText);
                result.Result = new BadRequestObjectResult(resultObj);
            }
        }
    }
}
