using Blockcchain_demo.Modules.Users.App.Interfaces;
using Blockcchain_demo.Modules.Users.Commands;
using Blockchain_demo.Modules.Users.Core.Entities;
using Blockchain_demo.Modules.Users.Exceptions;
using Blockchain_demo.Modules.Users.Infrastructure.Repositories;
using Blockchain_demo.Modules.Users.Infrastructure.Services;
using Blockchain_demo.Modules.Users.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Blockchain_demo.Modules.Users.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }

        public static WebApplication AddUsersApi(this WebApplication app)
        {
            app.MapPost("/user", async (HttpContext context, CreateUserCommand request, IUserService userService) =>
            {
                try
                {
                    await userService.CreateUser(request);
                    context.Response.StatusCode = StatusCodes.Status201Created;

                    return Results.Created("/", null);
                }
                catch (InvalidUserException uex)
                {
                    return Results.BadRequest(new ErrorRsponse(StatusCodes.Status400BadRequest, uex.Message));
                }
            });

            app.MapPost("/user/login", async (HttpContext context, AuthenticateUserCommand request, IUserService userService) =>
            {
                try
                {
                    string token = await userService.AuthenticateUser(request);
                    return Results.Ok(new AuthenticatedResult(token));
                }
                catch (InvalidCredentialsException ex)
                {
                    return Results.BadRequest(new ErrorRsponse(StatusCodes.Status400BadRequest, ex.Message));
                }
            });
            return app;
        }
    }
}
