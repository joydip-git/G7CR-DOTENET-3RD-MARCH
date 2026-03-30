using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IRepository<ProductDTO> repository) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            return await repository.GetAsync();
        }
    }
}
