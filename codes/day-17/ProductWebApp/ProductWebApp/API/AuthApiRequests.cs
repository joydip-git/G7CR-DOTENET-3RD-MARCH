using Microsoft.Extensions.Options;
using ProductWebApp.Models;

namespace ProductWebApp.API
{
    public class AuthApiRequests(IOptions<ApiRequestBaseUrls> options, IHttpClientFactory httpClientFactory) : IAuthApiRequests
    {
        public async Task<string> SendRequestToLOginAsync(LoginModel model)
        {
            using HttpClient client = httpClientFactory.CreateClient("ApiClient");
            HttpResponseMessage? response = await client.PostAsJsonAsync<LoginModel>($"{options.Value.AuthApiBaseUrl}/login", model);
            string? token = await response?.Content.ReadAsStringAsync();
            return token;
        }
    }
}
