using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBeholder.Api.Models;
using TheBeholder.Data;
using TheBeholder.Data.Mapging;

namespace TheBeholder.Api.Configurations
{
    public static class DbConfig
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {

            var appSettingsSection = configuration.GetSection("MongoDbConnection");
            services.Configure<MongoDbConnection>(appSettingsSection);

            var mongoDbConnection  = appSettingsSection.Get<MongoDbConnection>();

            services.AddScoped<IDbMongo>(factory => new DbMongo(mongoDbConnection.ConnectionString, mongoDbConnection.Database));

            MongoDbPersistence.Configure();

            return services;
        }
    }
}