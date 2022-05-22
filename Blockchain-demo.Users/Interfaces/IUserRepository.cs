using Blockcchain_demo.Server.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Blockcchain_demo.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}