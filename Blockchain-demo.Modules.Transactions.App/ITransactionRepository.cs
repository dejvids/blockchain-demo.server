using Blockchain_demo.Modules.Transactions.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blockchain_demo.Modules.Transactions.App
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetAsync(string id);
        Task AddAsync(Transaction transaction);
        Task DeleteAsync(string id);
        Task<ICollection<Transaction>> GetAllAsync();
    }
}
