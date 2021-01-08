using MongoDB.Bson.Serialization;
using TheBeholder.Business.Models;

namespace TheBeholder.Data.Mapging
{
    public class EntityBaseMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(map =>
            {
                map.AutoMap();
                map.MapIdMember(x => x.Id);
            });


        }
    }
}