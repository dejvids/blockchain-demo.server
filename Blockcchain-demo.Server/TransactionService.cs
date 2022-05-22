using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Blockcchain_demo.Server
{
   
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepositroy)
        {
            _transactionRepository = transactionRepositroy;
        }

        public async Task<TransactionResponse> AddTransactionAsync(TransactionRequest transactionRequest)
        {
            var newTransaction = new Entities.Transaction
            {
                Sender = transactionRequest.Sender,
                Reciever = transactionRequest.Reciever,
                Amount = transactionRequest.Amount,
                CreateDate = DateTime.UtcNow,
            };

            newTransaction.SetHash();
            await _transactionRepository.AddAsync(newTransaction);

            return new TransactionResponse(newTransaction.Id, newTransaction.Sender, newTransaction.Reciever, newTransaction.Amount, newTransaction.CreateDate, newTransaction.Hash);
        }

        public async Task DeleteTransactionAsync(string id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task <TransactionResponse?> FindTransactionAsync(string id)
        {
            var transaction =  await _transactionRepository.GetAsync(id);
            if (transaction == null)
            {
                return null;
            }

            return new TransactionResponse(transaction.Id, transaction.Sender, transaction.Reciever, transaction.Amount, transaction.CreateDate, transaction.Hash);
        }

        public async Task<ICollection<TransactionResponse>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();

            return transactions.Select(t => new TransactionResponse(t.Id, t.Sender, t.Reciever, t.Amount, t.CreateDate, t.Hash)).ToList();
        }
    }
}
