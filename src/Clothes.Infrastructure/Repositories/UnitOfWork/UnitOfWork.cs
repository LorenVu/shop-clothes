using MinimalApi.Domain.Constracts;
using MinimalApi.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        context.SaveChangesAsync(cancellationToken);
}