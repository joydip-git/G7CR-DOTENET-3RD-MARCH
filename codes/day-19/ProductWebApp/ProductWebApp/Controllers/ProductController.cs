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
                IEnumerable<ProductModel>? all = await productApi.SendAllProductsRequestAsync();
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
                ProductModel? single = await productApi.SendAProductRequestAsync(id);
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
                if (this.ModelState.IsValid)
                {
                    logger.LogInformation(product.Name);
                    ProductModel? addedProduct = await productApi.SendAnAddProductRequestAsync(product);
                    return RedirectToAction("AllProducts");
                }
                else
                    throw new Exception("Model is invalid");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            try
            {
                logger.LogInformation("in update: " + id.ToString());
                ProductModel? single = await productApi.SendAProductRequestAsync(id);
                logger.LogInformation(single != null ? single.Name : "NA");
                return View(single);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel product)
        {
            try
            {
                _ = await productApi.SendAnUpdateProductRequestAsync(product);
                return RedirectToAction("AllProducts");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                _ = await productApi.SendADeleteProductRequestAsync(productId);
                return this.RedirectToAction("AllProducts");
            }
            catch
            {
                throw;
            }
        }
    }
}
