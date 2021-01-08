using Microsoft.Extensions.DependencyInjection;
using TheBeholder.Business;
using TheBeholder.Business.Interfaces;
using TheBeholder.Business.Services;
using TheBeholder.Data;

namespace TheBeholder.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
                services.AddScoped<IDetailRepository, DetailRepository>();
                services.AddScoped<IHtmlWrapperFacade, HtmlWrapperFacade>();
                services.AddScoped<ISaveTicketsFromHtmlService, SaveTicketsFromHtmlService>();
                services.AddScoped<IFundamentusWrapper,FundamentusWrapper>();
                services.AddScoped(typeof(IRepository<>), typeof(MongoDbRepository<>));                
                return services;
        }
    }
}