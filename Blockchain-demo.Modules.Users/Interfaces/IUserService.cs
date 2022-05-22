using Blockcchain_demo.Modules.Users.Commands;
using System.Threading.Tasks;

namespace Blockchain_demo.Modules.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserCommand command);
        Task<string> AuthenticateUser(AuthenticateUserCommand command);
        Task DeleteUser(DeleteUserCommand command);
    }
}
