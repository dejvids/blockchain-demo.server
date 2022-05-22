using Blockcchain_demo.Modules.Users.App.Interfaces;
using Blockchain_demo.Modules.Users.Core.Entities;
using Blockchain_demo.Shared.Database;
using MongoDB.Driver;

namespace Blockchain_demo.Modules.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbOptions _dbOptions;

        public UserRepository(IMongoClientFactory mongoClientFactory, MongoDbOptions dbOptions)
        {
            _mongoClientFactory = mongoClientFactory;
            _dbOptions = dbOptions;
        }
        public async Task CreateUserAsync(User user)
        {
            await Collection().InsertOneAsync(user);
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await Collection().Find(u => u.Username == username).FirstOrDefaultAsync();
        }

        private IMongoCollection<User> Collection()
        {
            MongoClient mongo = _mongoClientFactory.CreateDefaultClient();
            IMongoDatabase db = mongo.GetDatabase(_dbOptions.DatabaseName);

            return db.GetCollection<User>(_dbOptions.UsersCollection);
        }
    }
}
