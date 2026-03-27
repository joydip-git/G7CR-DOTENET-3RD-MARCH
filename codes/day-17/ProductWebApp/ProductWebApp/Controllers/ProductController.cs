using Microsoft.AspNetCore.Mvc;
using ProductWebApp.API;
using ProductWebApp.Models;

namespace ProductWebApp.Controllers
{
    public class ProductController(IProductApiRequests productApi, ILogger<ProductController> logger) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet(Name = "AllProducts")]
        public async Task<IActionResult> AllProducts()
        {
            try
            {
                var all = await productApi.SendAllProductsRequest();
                return this.View(all);
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                logger.LogInformation(id.ToString());
                var single = await productApi.SendAProductRequest(id);
                return View(single);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            try
            {
                logger.LogInformation(product.Name);
                var addedProduct = await productApi.SendAnAddProductRequest(product);
                return RedirectToAction("AllProducts");
            }
            catch
            {
                throw;
            }
        }
    }
}
