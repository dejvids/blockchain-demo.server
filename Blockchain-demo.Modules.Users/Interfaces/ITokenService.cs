using Blockchain_demo.Modules.Users.Core.Entities;

namespace Blockchain_demo.Modules.Users.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(User user);
        bool ValidateToken(string token);
    }
}
