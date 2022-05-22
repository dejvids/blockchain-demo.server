using Blockchain_demo.Modules.Transactions.App;
using Blockchain_demo.Modules.Transactions.Infrastructure.Services;
using Blockchain_demo.Modules.Transactions.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Blockchain_demo.Modules.Transactions.Core.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Blockchain_demo.Modules.Transactions.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddTransactionModule(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }

        public static WebApplication AddTransactionEndpoints(this WebApplication app)
        {
            app.MapGet("/transaction", async (HttpContext context, ITransactionService txService) =>
            {
                context.Response.ContentType = "application/json";
                return await txService.GetAllAsync();
            });
            app.MapGet("/transaction/{id}", async (HttpContext context, string id, ITransactionService txService) =>
            {
                var response = await txService.FindTransactionAsync(id);

                if (response == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(response);
            });

            app.MapPost("/transaction", [Authorize] async (HttpContext context, NewTransactionDto transaction, ITransactionService txService) =>
            {
                var response = await txService.AddTransactionAsync(transaction);
                context.Response.StatusCode = StatusCodes.Status201Created;
                return Results.Created("/transaction", response);
            });

            app.MapDelete("/transaction/{hash}", [Authorize] async (ITransactionService txService, string hash)
                => await txService.DeleteTransactionAsync(hash));

            return app;
        }
    }
}
