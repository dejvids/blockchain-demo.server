using MongoDB.Driver;

namespace Blockchain_demo.Shared.Database
{
    public interface IMongoClientFactory
    {
        MongoClient CreateDefaultClient();
    }
}
