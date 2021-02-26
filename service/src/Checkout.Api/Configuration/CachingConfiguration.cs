namespace Checkout.Api.Configuration
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class CachingConfiguration
    {
        public static IServiceCollection RegisterCaching(this IServiceCollection services)
        {
            //Uncomment to use in memory cache implementation of IDistributedCache
            //useful during development, or for single server deployments
            return services
                .AddDistributedMemoryCache();

            ////Uncomment to use Azure Cache For Redis implementation
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = Environment.GetEnvironmentVariable("ConnectionStrings__FinanceConnectionString");
            //});
        }
    }
}