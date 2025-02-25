using Microsoft.EntityFrameworkCore;

namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}