using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace TheBeholder.Data.Mapging
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));
            EntityBaseMap.Configure();
        }
    }
}