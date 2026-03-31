using ProductWebApp.Models;

namespace ProductWebApp.API
{
    public interface IAuthApiRequests
    {
        Task<string> SendRequestToLOginAsync(LoginModel model);
        //Task<string> SendRequestToLOginAsync(LoginModel model);
    }
}
