using Blockchain_demo.Modules.Transactions.Core.DTO;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain_demo.Modules.Transactions.Core.Entities
{
    public class Transaction
    {
        public string Id => Hash;
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string Hash { get; set; }

        public void SetHash()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Sender)
                .Append(Reciever)
                .Append(Amount)
                .Append(new DateTimeOffset(CreateDate).ToUnixTimeSeconds());

            byte[] hashData = SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(str.ToString()));

            StringBuilder sb = new StringBuilder(hashData.Length * 2);
            foreach (byte b in hashData)
            {
                sb.AppendFormat("{0:x2}", b);
            }

            Hash = sb.ToString();
        }

        public TransactionDto MapToTransactionDto()
        {
            return new TransactionDto
            {
                Id = this.Id,
                Sender = this.Sender,
                Reciever = this.Reciever,
                Amount = this.Amount,
                CreateDate = this.CreateDate,
                Hash = this.Hash
            };
        }

        public static Transaction CreateFromDto(NewTransactionDto newTransaction)
        {
            return new Transaction
            {
                Sender = newTransaction.Sender,
                Reciever = newTransaction.Reciever,
                Amount = newTransaction.Amount,
                CreateDate = DateTime.UtcNow,
            };
        }
    }
}
