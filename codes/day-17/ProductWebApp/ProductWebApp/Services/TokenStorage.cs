namespace ProductWebApp.Services
{
    public class TokenStorage : ITokenStorage
    {
        private string? accessToken = null;
        public void SaveToken(string? token)
        {
            accessToken = token;
        }
        public string? GetToken() => accessToken;
    }
}
