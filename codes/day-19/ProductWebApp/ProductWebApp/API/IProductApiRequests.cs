using ProductWebApp.Models;

namespace ProductWebApp.API
{
    public interface IProductApiRequests
    {
        Task<IEnumerable<ProductModel>?> SendAllProductsRequestAsync();
        Task<ProductModel?> SendAProductRequestAsync(int id);
        Task<ProductModel?> SendAnAddProductRequestAsync(ProductModel productModel);
        Task<ProductModel?> SendAnUpdateProductRequestAsync(ProductModel productModel);
        Task<ProductModel?> SendADeleteProductRequestAsync(int id);
    }
}