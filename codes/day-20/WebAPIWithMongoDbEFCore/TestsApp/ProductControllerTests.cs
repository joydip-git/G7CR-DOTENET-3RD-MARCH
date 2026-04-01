using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Models;

namespace TestsApp
{
    [TestClass]
    public sealed class ProductControllerTests
    {
        [TestMethod]
        public async Task GetByIdAsyncTest()
        {
            //arrange
            var moqRepo = new Mock<IRepository<ProductDTO>>();
            moqRepo
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new ProductDTO { ProductName = "dell xps", ProductId = 100, Description = "desc", Price = 1000 });

            var controller = new ProductController(moqRepo.Object);
            ActionResult<ProductDTO?> result = await controller.GetProductByIdAsync(100);
            //Assert.IsInstanceOfType<ProductDTO?>(typeof(ProductDTO), out result.Value);
        }
    }
}
