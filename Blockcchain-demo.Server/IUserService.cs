using System.Threading.Tasks;

namespace Blockcchain_demo.Server
{
    public interface IUserService
    {
        Task CreateUser(CreateUserCommand command);
        Task<string> AuthenticateUser(AuthenticateUserCommand command);
        Task DeleteUser(DeleteUserCommand command);
    }
}
