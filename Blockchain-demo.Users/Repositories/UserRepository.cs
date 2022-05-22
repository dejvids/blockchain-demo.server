using Blockcchain_demo.Server.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Blockcchain_demo.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string COLLECTION_NAME_KEY = "UsersCollection";
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly IConfiguration _configuration;

        public UserRepository(IMongoClientFactory mongoClientFactory, IConfiguration configuration)
        {
            _mongoClientFactory = mongoClientFactory;
            _configuration = configuration.GetSection("Mongo");
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
            IMongoDatabase db = mongo.GetDatabase(_configuration["DatabaseName"]);

            return db.GetCollection<User>(_configuration[COLLECTION_NAME_KEY]);
        }
    }
}
