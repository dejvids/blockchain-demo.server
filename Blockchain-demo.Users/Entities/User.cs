using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Blockcchain_demo.Server.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonRequired]
        public string? Username { get; set; }
        [BsonRequired]
        public string? PasswordHash { get; set; }
    }
}
