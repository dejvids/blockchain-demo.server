using Blockchain_demo.Modules.Transactions.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blockchain_demo.Modules.Transactions.App
{
    public interface ITransactionService
    {
        Task<TransactionDto> FindTransactionAsync(string id);
        Task<TransactionDto> AddTransactionAsync(NewTransactionDto transaction);
        Task<ICollection<TransactionDto>> GetAllAsync();
        Task DeleteTransactionAsync(string hash);
    }
}
