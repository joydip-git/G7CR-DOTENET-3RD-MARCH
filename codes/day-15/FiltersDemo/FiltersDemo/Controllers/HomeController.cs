using FiltersDemo.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[CommonExceptionFilter]
    [TypeFilter<CommonExceptionFilterAttribute>]
    public class HomeController : ControllerBase
    {
        [Route("welcome/{name}")]
        [HttpGet]
        //[CommonExceptionFilter]
        // [TypeFilter<CommonExceptionFilterAttribute>]
        public ActionResult<string> Get(string name)
        {

            if (name.Length == 6)
                return new ObjectResult($"Welcome {name}");
            else
                throw new Exception("lengthy or short name..should be exact 6 chars long");
        }

        [Route("hello")]
        [HttpGet]
        public ActionResult SayHello()
        {
            throw new Exception("something went wrong");
        }
    }
}
