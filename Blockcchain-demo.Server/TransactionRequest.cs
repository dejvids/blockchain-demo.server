using System;
using System.Text.Json.Serialization;

namespace Blockcchain_demo.Server
{
    public record TransactionRequest(string Sender, string Reciever, decimal Amount);
    public record TransactionResponse
    {
        public TransactionResponse(string id, string sender, string reciever, decimal amount, DateTime createDate, string hash)
        {
            Id = id;
            Sender = sender;
            Reciever = reciever;
            Amount = amount;
            CreateDate = createDate;
            Hash = hash;
        }

        public string Id { get; set; }
        [JsonPropertyName("from")]
        public string? Sender { get; set; }
        [JsonPropertyName("to")]
        public string? Reciever { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string Hash { get; set; }
    }
}