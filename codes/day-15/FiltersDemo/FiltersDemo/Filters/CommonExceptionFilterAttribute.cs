using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace FiltersDemo.Filters
{
    public class CommonExceptionFilterAttribute(ILogger<CommonExceptionFilterAttribute> logger) : IExceptionFilter
    //public class CommonExceptionFilterAttribute(ILogger<CommonExceptionFilterAttribute> logger) : ExceptionFilterAttribute
    {
        public  void OnException(ExceptionContext context)
        //public override void OnException(ExceptionContext context)
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
