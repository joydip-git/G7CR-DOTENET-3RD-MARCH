using Microsoft.AspNetCore.Mvc;
using ProductWebApp.API;
using ProductWebApp.Models;
using ProductWebApp.Services;

namespace ProductWebApp.Controllers
{
    public class AuthController(ILogger<AuthController> logger, IAuthApiRequests authApi, ITokenStorage tokenStorage) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            string? token = await authApi.SendRequestToLOginAsync(login);
            if (token != null)
            {
                //this.HttpContext.Session.SetString("token", token);
                tokenStorage.SaveToken(token);
                return RedirectToAction(actionName: "AllProducts", controllerName: "product");
            }
            else
            {
                ViewData["message"] = "Not a valid user";
                return View();
            }
        }
    }
}
