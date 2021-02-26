namespace Checkout.Infrastructure.Data.UnitOfWork
{
    using System.Linq;

    public interface IFinanceUnitOfWork : IQueryableUnitOfWork
    {
        IQueryable<BankAccount> BankAccount { get; }

        IQueryable<BankPosting> BankPosting { get; }

        IQueryable<Category> Category { get; }

        IQueryable<Creditor> Creditor { get; }
    }
}