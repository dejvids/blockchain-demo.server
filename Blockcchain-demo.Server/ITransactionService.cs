using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blockcchain_demo.Server
{
    public interface ITransactionService
    {
        Task<TransactionResponse> FindTransactionAsync(string id);
        Task<TransactionResponse> AddTransactionAsync(TransactionRequest transaction);
        Task<ICollection<TransactionResponse>> GetAllAsync();
        Task DeleteTransactionAsync(string hash);
    }
}
