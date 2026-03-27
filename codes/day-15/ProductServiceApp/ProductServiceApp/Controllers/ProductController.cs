using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ProductServiceApp.DTOs;
using ProductServiceApp.Models.Repository.Abstractions;

namespace ProductServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("mypolicy")]
    public class ProductController(IRepository<ProductDTO, int> repository) : ControllerBase
    {
        //[EnableCors("mypolicy")]
        [Route("all")]
        [HttpGet]
        [Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            try
            {
                var all = repository.GetAll();
                if (all?.Count() > 0)
                    return this.Ok(all);
                else
                    return this.NoContent();
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductDTO> GetProduct([FromRoute(Name = "id")] int productId)
        {
            try
            {
                var product = repository.Get(productId);
                if (product != null)
                    return this.Ok(product);
                else
                    return this.NoContent();
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }


        [HttpPost]
        [Route("add")]
        public ActionResult<ProductDTO> AddProduct([FromBody] ProductDTO product)
        {
            try
            {
                var addedDto = repository.Add(product);
                return this.CreatedAtAction(nameof(AddProduct), addedDto);
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpPut]
        [Route("edit/{id}")]
        public ActionResult<ProductDTO> UpdateProduct([FromRoute(Name="id")] int productId, [FromBody] ProductDTO product)
        {
            try
            {
                var editedDto = repository.Update(productId,product);
                return this.CreatedAtAction(nameof(UpdateProduct), editedDto);
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<ProductDTO> DeleteProduct([FromRoute(Name = "id")] int productId)
        {
            try
            {
                var deletedDto = repository.Delete(productId);
                return this.Ok(deletedDto);
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }
    }
}
