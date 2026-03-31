namespace ProductWebApp.Services
{
    public interface ITokenStorage
    {
        string? GetToken();
        void SaveToken(string? token);
    }
}