namespace Checkout.Infrastructure.Data.ShoppingBasket.Repositories
{
    using Core;
    using Domain.ShoppingBasket.Aggregates.BasketAggregate;
    using Microsoft.Extensions.Caching.Distributed;

    public class BasketRepository
        : Repository<Basket>, IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
            : base(cache)
        {
            _cache = cache;
        }
    }
}