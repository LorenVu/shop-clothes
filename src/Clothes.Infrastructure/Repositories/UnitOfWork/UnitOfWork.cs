using Clothes.Domain.Constracts;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        context.SaveChangesAsync(cancellationToken);
}