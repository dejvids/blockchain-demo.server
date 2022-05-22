using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blockcchain_demo.Server.Entities;

namespace Blockcchain_demo.Server
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetAsync(string id);
        Task AddAsync(Transaction transaction);
        Task DeleteAsync(string id);
        Task<ICollection<Transaction>> GetAllAsync();
    }
}
