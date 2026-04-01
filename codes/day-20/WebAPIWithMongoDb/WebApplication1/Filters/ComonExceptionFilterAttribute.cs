using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WebApplication1.Filters
{
    public class CommonExceptionFilterAttribute(ILogger<CommonExceptionFilterAttribute> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var e = context.Exception;
            logger.LogError(e.Message + Environment.NewLine + e.TargetSite?.Name);
            var errorResponse = new
            {
                Message = e.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.Result = new JsonResult(errorResponse);

            context.ExceptionHandled = true;
        }
    }
}
