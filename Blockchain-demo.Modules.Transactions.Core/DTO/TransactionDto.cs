using System;
using System.Text.Json.Serialization;

namespace Blockchain_demo.Modules.Transactions.Core.DTO
{
    public record TransactionDto
    {
        public string Id { get; init; }
        [JsonPropertyName("from")]
        public string? Sender { get; init; }
        [JsonPropertyName("to")]
        public string? Reciever { get; init; }
        public decimal Amount { get; init; }
        public DateTime CreateDate { get; init; }
        public string Hash { get; init; }
    }
}
