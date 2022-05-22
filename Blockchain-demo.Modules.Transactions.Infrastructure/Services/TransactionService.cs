using Blockchain_demo.Modules.Transactions.App;
using Blockchain_demo.Modules.Transactions.Core.DTO;
using Blockchain_demo.Modules.Transactions.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain_demo.Modules.Transactions.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepositroy)
        {
            _transactionRepository = transactionRepositroy;
        }

        public async Task<TransactionDto> AddTransactionAsync(NewTransactionDto transactionRequest)
        {
            var newTransaction = Transaction.CreateFromDto(transactionRequest);

            newTransaction.SetHash();
            await _transactionRepository.AddAsync(newTransaction);

            return newTransaction.MapToTransactionDto();
        }

        public async Task DeleteTransactionAsync(string id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task<TransactionDto?> FindTransactionAsync(string id)
        {
            var transaction = await _transactionRepository.GetAsync(id);
            if (transaction == null)
            {
                return null;
            }

            return transaction.MapToTransactionDto();
        }

        public async Task<ICollection<TransactionDto>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();

            return transactions.Select(t => t.MapToTransactionDto()).ToList();
        }
    }
}
