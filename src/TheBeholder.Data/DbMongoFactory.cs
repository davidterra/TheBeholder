using MongoDB.Driver;

namespace TheBeholder.Data
{
    public sealed class DbMongoFactory
    {
        public static MongoClient GetClient(string connectionString) => new MongoClient(connectionString);

    }
}