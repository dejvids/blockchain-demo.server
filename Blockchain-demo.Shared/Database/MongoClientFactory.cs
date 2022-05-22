using Blockcchain_demo.Shared.Exceptions;
using MongoDB.Driver;

namespace Blockchain_demo.Shared.Database
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbOptions _dbOptions;
        public MongoClientFactory(MongoDbOptions options)
        {
            _dbOptions = options;
        }

        public MongoClient CreateDefaultClient()
        {
            string connectionString = _dbOptions.ConnectionString;

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidConfigurationException($"Missing section Mongo:ConnectionString");
            }

            return new MongoClient(_dbOptions.ConnectionString);
        }
    }
}
