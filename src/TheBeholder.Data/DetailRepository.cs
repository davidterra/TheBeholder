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
            => await Collection.Find(filter => filter.Ticket == ticket.ToUpper())
                                .SortByDescending(sort => sort.CreatedAt)
                                .FirstOrDefaultAsync();
    }
}