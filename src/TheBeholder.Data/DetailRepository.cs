using System.Threading.Tasks;
using MongoDB.Driver;
using TheBeholder.Business.Interfaces;
using TheBeholder.Business.Models;
using System.Linq;
using MongoDB.Bson;

namespace TheBeholder.Data
{

    public class DetailRepository : MongoDbRepository<Detail>, IDetailRepository
    {
        protected override IMongoCollection<Detail> Collection { get; }

        public DetailRepository(IDbMongo dbMongo)
            : base(dbMongo)
                => this.Collection = dbMongo.Collection<Detail>();

        public async Task<Detail> GetByTicketAsync(string ticket)
        {
            var result = await this.Collection.FindAsync<Detail>(filter => filter.Ticket == ticket.ToUpper());

            // var minDocument = collection.Find(query).SetSortOrder(sortAscending).SetLimit(1).First();
            // var maxDocument = collection.Find(query).SetSortOrder(sortDescending).SetLimit(1).First();

            // var minDateTime = minDocument["Entry"].AsDateTime;
            // var maxDateTime = maxDocument["Entry"].AsDateTime;

            // var builder = Builders<BsonDocument>.Sort;
            // var sort = builder.Ascending("x").Descending("y");

            // var sortDescending = SortBy.Descending("Entry");

            // var max = Collection.Find().SetSortOrder()

            // var builder = Builders<BsonDocument>.Sort;
            // var sort = builder.Descending("CreatedAt");

           return await  Collection.Find(filter => filter.Ticket == ticket.ToUpper()).SortByDescending(sort => sort.CreatedAt).FirstOrDefaultAsync();
        }
    }
}