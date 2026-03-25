using FiltersDemo.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("hello")]
        [HttpGet]
        //[CommonExceptionFilter]
        [TypeFilter<CommonExceptionFilterAttribute>]
        public ActionResult SayHello()
        {
            throw new Exception("something went wrong");
        }
    }
}
