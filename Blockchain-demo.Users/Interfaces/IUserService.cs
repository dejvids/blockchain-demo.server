using System.Threading.Tasks;

namespace Blockcchain_demo.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserCommand command);
        Task<string> AuthenticateUser(AuthenticateUserCommand command);
        Task DeleteUser(DeleteUserCommand command);
    }
}
