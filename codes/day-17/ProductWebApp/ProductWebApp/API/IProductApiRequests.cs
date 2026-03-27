using ProductWebApp.Models;

namespace ProductWebApp.API
{
    public interface IProductApiRequests
    {
        Task<IEnumerable<ProductModel>?> SendAllProductsRequest();
        Task<ProductModel?> SendAProductRequest(int id);
        Task<ProductModel?> SendAnAddProductRequest(ProductModel productModel);
    }
}