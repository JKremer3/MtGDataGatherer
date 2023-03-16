using Microsoft.Extensions.DependencyInjection;
using MtgApiManager.Lib.Service;

namespace MTGDataGatherer.service
{
    public static class CardFetcherExtension
    {
        public static IServiceCollection AddCardFetcher(this IServiceCollection services)
        {
            services.AddScoped<IMtgServiceProvider, MtgServiceProvider>();
            services.AddScoped<ICardFetcher, CardFetcher>();
            
            return services;
        }
    }
}