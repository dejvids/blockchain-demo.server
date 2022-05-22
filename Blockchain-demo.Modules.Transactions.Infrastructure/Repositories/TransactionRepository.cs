using Blockchain_demo.Modules.Transactions.App;
using Blockchain_demo.Modules.Transactions.Core.Entities;
using Blockchain_demo.Shared.Database;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blockchain_demo.Modules.Transactions.Infrastructure.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbOptions _dbOptions;

        public TransactionRepository(IMongoClientFactory mongoClientFactory,  MongoDbOptions dbOptions)
        {
            _mongoClientFactory = mongoClientFactory;
            _dbOptions = dbOptions;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await Collection().InsertOneAsync(transaction);
        }

        public async Task DeleteAsync(string hash)
        {
            await Collection().DeleteOneAsync(t => t.Hash == hash);
        }

        public async Task<ICollection<Transaction>> GetAllAsync()
        {
            return await Collection().Find(_ => true).ToListAsync();
        }

        public async Task<Transaction?> GetAsync(string id)
        {
            return await Collection().Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        private IMongoCollection<Transaction> Collection()
        {
            MongoClient mongo = _mongoClientFactory.CreateDefaultClient();
            IMongoDatabase db = mongo.GetDatabase(_dbOptions.DatabaseName);

            return db.GetCollection<Transaction>(_dbOptions.TransactionsCollection);
        }
    }
}
