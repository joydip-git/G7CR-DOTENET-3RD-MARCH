using ProductWebApp.Services;
using System.Net.Http.Headers;

namespace ProductWebApp.Interceptors
{
    //public class TokenInterceptor(ITokenStorage tokenStorage, ILogger<TokenInterceptor> logger, IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    public class TokenInterceptor(ITokenStorage tokenStorage, ILogger<TokenInterceptor> logger) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //strin? token = httpContextAccessor.HttpContext.Session["token"];
            string? token = tokenStorage.GetToken();
            logger.LogInformation(token ?? "Not found");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
