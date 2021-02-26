namespace Checkout.Domain.Core
{
    using System;

    [Serializable]
    public abstract class AggregateRoot : Entity<Guid>
    {
        protected AggregateRoot()
        {
        }
    }
}