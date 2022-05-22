using Blockchain_demo.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockcchain_demo.Server
{
    public class StaticTransactionRepository : ITransactionRepository
    {
        private readonly IMongoClientFactory _mongoClientFactory;

        public StaticTransactionRepository(IMongoClientFactory mongoClientFactory)
        {
            _mongoClientFactory = mongoClientFactory;
        }

        public Task AddAsync(Transaction transaction)
        {
            TransactionsDB.Transactions.Add(transaction);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Transaction>> GetAllAsync()
        {
            return Task.FromResult<ICollection<Transaction>>(TransactionsDB.Transactions.ToList());
        }

        public Task<Transaction?> GetAsync(string id)
        {
            return Task.FromResult(TransactionsDB.Transactions.FirstOrDefault(t => t.Id == id));
        }

        public Task UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        private static class TransactionsDB
        {
            public static List<Transaction> Transactions = new();
        }

    }
}
