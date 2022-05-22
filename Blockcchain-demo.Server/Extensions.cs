using Blockcchain_demo.Shared.Exceptions;
using Blockchain_demo.Shared.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockcchain_demo.Server
{
    public static class Extensions
    {
        public static IServiceCollection AddDbOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConfig = configuration.GetSection("Mongo");
            string connectionString = null;

            if (mongoConfig != null)
            {
                connectionString = mongoConfig["ConnectionString"];
            }

            if (connectionString == null)
            {
                throw new InvalidConfigurationException($"Missing section Mongo:ConnectionString");
            }
            var dbOptions = new MongoDbOptions
            {
                ConnectionString = connectionString,
                DatabaseName = mongoConfig["DatabaseName"],
                UsersCollection = mongoConfig["UsersCollection"],
                TransactionsCollection = mongoConfig["TransactionsCollection"]
            };


            services.AddSingleton(dbOptions);

            return services;
        }
    }
}
