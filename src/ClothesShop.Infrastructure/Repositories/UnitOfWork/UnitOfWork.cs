using Clothes.Domain.Constracts;
using Clothes.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    private readonly TContext _context;
    public UnitOfWork(TContext context)
    {
        this._context = context;
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}