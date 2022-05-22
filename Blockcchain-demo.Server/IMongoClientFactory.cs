using MongoDB.Driver;

namespace Blockcchain_demo.Server
{
    public interface IMongoClientFactory
    {
        MongoClient CreateDefaultClient();
    }
}
