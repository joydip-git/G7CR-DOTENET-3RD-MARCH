using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspNetCoreApp.Controllers
{
    [Route("home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("welcome/{name}")]
        public string SayWelcome([FromRoute(Name = "name")] string personName)
        {
            return "welcome..." + personName;
        }

        [HttpGet]
        [Route("hello")]
        public string SayHello()
        {
            return "Hello...";
        }

        [HttpGet]
        [Route("people")]
        public IActionResult GetPeople()
        {
            try
            {
                var people1 = new { FirstName = "aman", LastName = "gupta" };
                var people2 = new { FirstName = "joydip", LastName = "mondal" };
                OkObjectResult okRes = this.Ok(new[] { people1, people2 });
                return okRes;
            }
            catch (Exception e)
            {
                var problem = this.Problem(detail: e.Message, statusCode: 500);
                return problem;
            }
        }
    }
}
