using Blockcchain_demo.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockchain_demo.Shared.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
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
            services.AddScoped<IMongoClientFactory, MongoClientFactory>();

            return services;
        }
    }

}
