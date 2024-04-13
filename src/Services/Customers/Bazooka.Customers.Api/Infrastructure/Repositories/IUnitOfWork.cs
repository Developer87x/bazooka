namespace Bazooka.Customers.Api.Infrastructure.Repositories;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken =default);
}
