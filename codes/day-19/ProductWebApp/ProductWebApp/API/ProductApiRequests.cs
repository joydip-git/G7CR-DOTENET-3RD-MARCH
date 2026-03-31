using Microsoft.Extensions.Options;
using ProductWebApp.Models;
using ProductWebApp.Services;
using System.Net.Http.Headers;

namespace ProductWebApp.API
{
    public class ProductApiRequests(IConfiguration configuration, IOptions<ApiRequestBaseUrls> options, ITokenStorage tokenStorage, ILogger<ProductApiRequests> logger, IHttpClientFactory httpClientFactory) : IProductApiRequests
    {
        public async Task<IEnumerable<ProductModel>?> SendAllProductsRequestAsync()
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient("ApiClient");
                string requestUrl = $"{configuration.GetRequiredSection("ApiRequestBaseUrls:ProductApiBaseUrl").Value}/all";
                //logger.LogInformation(tokenStorage.GetToken());
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenStorage.GetToken());
                IEnumerable<ProductModel>? all = await httpClient.GetFromJsonAsync<List<ProductModel>>(requestUrl);
                return all;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductModel?> SendAProductRequestAsync(int id)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("ApiClient");
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/{id}";
            ProductModel? single = await httpClient.GetFromJsonAsync<ProductModel>(requestUrl);
            return single;
        }

        public async Task<ProductModel?> SendAnAddProductRequestAsync(ProductModel productModel)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("ApiClient");
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/add";
            HttpResponseMessage? response = await httpClient.PostAsJsonAsync<ProductModel>(requestUrl, productModel);
            var single = await response.Content.ReadFromJsonAsync<ProductModel>();
            return single;
        }

        public async Task<ProductModel?> SendAnUpdateProductRequestAsync(ProductModel productModel)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("ApiClient");
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/edit/{productModel.Id}";
            HttpResponseMessage? response = await httpClient.PutAsJsonAsync<ProductModel>(requestUrl, productModel);
            var single = await response.Content.ReadFromJsonAsync<ProductModel>();
            return single;
        }

        public async Task<ProductModel?> SendADeleteProductRequestAsync(int id)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("ApiClient");
            string requestUrl = $"{options.Value.ProductApiBaseUrl}/delete/{id}";
            ProductModel? deletedProduct = await httpClient.DeleteFromJsonAsync<ProductModel>(requestUrl);
            return deletedProduct;
        }
    }
}
