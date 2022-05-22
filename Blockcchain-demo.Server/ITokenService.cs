using Blockcchain_demo.Server.Entities;

namespace Blockcchain_demo.Server
{
    public interface ITokenService
    {
        string BuildToken(User user);
        bool ValidateToken(string token);
    }
}
