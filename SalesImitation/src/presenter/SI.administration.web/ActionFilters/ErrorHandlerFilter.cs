using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using SI.Common.Models;
using SI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SI.Common.Abstractions;

namespace SI.Administration.Web.ActionFilters
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
                    errorText = ex.Message;
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
