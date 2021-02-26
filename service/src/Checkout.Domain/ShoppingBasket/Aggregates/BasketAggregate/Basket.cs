namespace Checkout.Domain.ShoppingBasket.Aggregates.BasketAggregate
{
    using System;
    using Core;

    [Serializable]
    public class Basket : AggregateRoot
    {
        public Basket(
            string ipAddress,
            long sku)
        {
            IpAddress = ipAddress;
            Sku = sku;
        }

        public string IpAddress { get; }

        public long Sku { get; }
    }
}