using Chat.API.Models;

namespace Chat.API.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}