using System;

namespace Blockcchain_demo.Modules.Users.Commands
{
    public record CreateUserCommand(string Username, string Password);
    public record AuthenticateUserCommand(string Username, string Password);
    public record DeleteUserCommand(Guid Id);

    public record ErrorRsponse(int StatusCode, string message);
    public record AuthenticatedResult(string Token);
}
