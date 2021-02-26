namespace Checkout.Infrastructure.Data.Core
{
    using Microsoft.Extensions.Caching.Distributed;

    public interface ICache
    {
        IDistributedCache CreateSet();
    }
}