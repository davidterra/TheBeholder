using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TheBeholder.Business.Models;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq;
using TheBeholder.Business.Interfaces;

namespace TheBeholder.Data
{

    public class MongoDbRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected virtual IMongoCollection<TEntity> Collection { get; }
        public MongoDbRepository(IDbMongo dbMongo)
        {
            this.Collection = dbMongo.Collection<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
            => await this.Collection.DeleteOneAsync(filter => filter.Id == entity.Id);

        public async Task<IList<TEntity>> GetAllAsync()
            => await this.Collection.Find(new BsonDocument()).ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await this.Collection.FindAsync(filter => filter.Id == id);

            return result.FirstOrDefault();
        }        
        public async Task InsertAsync(TEntity entity)
            => await Collection.InsertOneAsync(entity);

        public async Task InsertAsync(IEnumerable<TEntity> entities) 
            => await this.Collection.InsertManyAsync(entities);


        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
            => this.Collection.AsQueryable<TEntity>()
                .Where(predicate.Compile())
                .ToList();

        public async Task UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);
            await this.Collection.ReplaceOneAsync(filter, entity);
        }
    }
}