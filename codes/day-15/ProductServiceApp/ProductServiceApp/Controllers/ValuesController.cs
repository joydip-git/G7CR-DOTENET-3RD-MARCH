using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("mypolicy")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("welcome")]
        public ActionResult Hello() => new JsonResult (new { Message = "hello" });
        //new ContentResult() { Content = "hello...", ContentType = "application/text", StatusCode = 200 }
    }
}
