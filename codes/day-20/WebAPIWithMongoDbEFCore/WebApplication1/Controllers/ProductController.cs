using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Validators;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter<CommonExceptionFilterAttribute>]
    public class ProductController(IRepository<ProductDTO> repository) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            return await repository.GetAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO?>> GetProductByIdAsync(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO product, [FromServices] IValidator<ProductDTO> validator)
        {
            var validationResult = await validator.ValidateAsync(product);
            if (validationResult.IsValid)
                return await repository.CreateAsync(product);
            else
                return this.BadRequest(validationResult.Errors);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, ProductDTO product)
        {
            return await repository.UpdateAsync(id, product);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ProductDTO?>> DeleteProduct(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
