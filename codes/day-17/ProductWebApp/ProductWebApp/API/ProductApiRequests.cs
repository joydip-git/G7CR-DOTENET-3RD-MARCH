using Microsoft.Extensions.Options;
using ProductWebApp.Models;

namespace ProductWebApp.API
{
    public class ProductApiRequests(IConfiguration configuration, IOptions<ApiRequestBaseUrls> options) : IProductApiRequests
    {        
        public async Task<IEnumerable<ProductModel>?> SendAllProductsRequest()
        {
            try
            {
                using HttpClient httpClient = new();
                string requestUrl = $"{configuration.GetRequiredSection("ApiRequestBaseUrls:ProductApiBaseUrl").Value}/all";
                IEnumerable<ProductModel>? all = await httpClient.GetFromJsonAsync<List<ProductModel>>(requestUrl);
                return all;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductModel?> SendAProductRequest(int id)
        {
            using HttpClient httpClient = new();
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/{id}";
            ProductModel? single = await httpClient.GetFromJsonAsync<ProductModel>(requestUrl);
            return single;
        }

        public async Task<ProductModel?> SendAnAddProductRequest(ProductModel productModel)
        {
            using HttpClient httpClient = new();
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/add";
            HttpResponseMessage? response = await httpClient.PostAsJsonAsync<ProductModel>(requestUrl, productModel);
            var single = await response.Content.ReadFromJsonAsync<ProductModel>();
            return single;
        }
    }
}
