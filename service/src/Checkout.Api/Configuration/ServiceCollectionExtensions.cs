namespace Checkout.Api.Configuration
{
    using Domain.ShoppingBasket.Aggregates.BasketAggregate;
    using Infrastructure.Data.ShoppingBasket.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddRepositories();
            //.AddUnitOfWork();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }

        //private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        //{
        //    return services.AddScoped<IFinanceUnitOfWork, FinanceUnitOfWork>();
        //}
    }
}