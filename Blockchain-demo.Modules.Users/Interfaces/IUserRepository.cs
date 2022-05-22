using Blockchain_demo.Modules.Users.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Blockcchain_demo.Modules.Users.App.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}