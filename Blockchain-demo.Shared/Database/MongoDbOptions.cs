namespace Blockchain_demo.Shared.Database
{
    public record MongoDbOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TransactionsCollection { get; set; }
        public string UsersCollection { get; set; }
    }
}
