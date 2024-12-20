using MinimalApi.Domain.Constracts;
using MinimalProject.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);
}