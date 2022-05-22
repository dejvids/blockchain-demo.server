using System;

namespace Blockchain_demo.Modules.Users.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
