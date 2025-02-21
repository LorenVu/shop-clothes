using Microsoft.EntityFrameworkCore;

namespace Clothes.Domain.Constracts;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}