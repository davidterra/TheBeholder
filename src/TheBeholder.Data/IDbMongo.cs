using MongoDB.Driver;
using TheBeholder.Business.Models;

namespace TheBeholder.Data
{
    public interface IDbMongo
    {        
        IMongoCollection<TEntity> Collection<TEntity>() where TEntity : EntityBase;
    }
}