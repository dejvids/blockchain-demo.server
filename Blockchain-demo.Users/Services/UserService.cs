using Blockcchain_demo.Server.Entities;
using Blockcchain_demo.Server.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Blockcchain_demo.Users.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IPasswordHasher<User> _hasher;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> hasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _tokenService = tokenService;
        }
        public async Task<string> AuthenticateUser(AuthenticateUserCommand command)
        {
            User user = await _userRepository.GetUserAsync(command.Username);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            if(_hasher.VerifyHashedPassword(user, user.PasswordHash, command.Password) != PasswordVerificationResult.Success)
            {
                throw new InvalidCredentialsException();
            }

            return _tokenService.BuildToken(user);
        }

        public async Task CreateUser(CreateUserCommand command)
        {
            if (!UserIsValid(command, out string message))
            {
                throw new InvalidUserException(message);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = command.Username
            };

            user.PasswordHash = _hasher.HashPassword(user, command.Password);

            await _userRepository.CreateUserAsync(user);
        }

        private bool UserIsValid(CreateUserCommand command, out string message)
        {
            if (string.IsNullOrEmpty(command.Username))
            {
                message = "Username cannot be empty";
                return false;
            }
            if (string.IsNullOrEmpty(command.Password))
            {
                message = "Password is required";
                return false;
            }
            if (command.Password.Length < 3)
            {
                message = "Password must have at least 3 charactesrs";
                return false;
            }

            message = string.Empty;
            return true;
        }

        public Task DeleteUser(DeleteUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
