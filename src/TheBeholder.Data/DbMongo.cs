using MongoDB.Driver;
using TheBeholder.Business.Models;

namespace TheBeholder.Data
{
    public class DbMongo : IDbMongo
    {
        protected MongoClient Client { get; }
        protected IMongoDatabase Database { get; }

        public DbMongo(string connectionString, string databaseName)
        {
            Client = DbMongoFactory.GetClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }

        public IMongoCollection<TEntity> Collection<TEntity>() 
            where TEntity : EntityBase 
                => Database.GetCollection<TEntity>(typeof(TEntity).Name);

    }
}