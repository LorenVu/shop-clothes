using Microsoft.EntityFrameworkCore;

namespace BuildingBlock.Shared.Seeds;

public class PagedList<T> : List<T>
{
    public PagedList(IEnumerable<T> items, long totalItems, int pageIndex, int pageSize)
    {
        _metadata = new Metadata
        {
            TotalItems = totalItems,
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalPages = (int) Math.Ceiling(totalItems / (double)pageSize)
        };

        AddRange(items);

        var x = Metadata;
    }

    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageIndex, int pageNumber, CancellationToken cancellationtoken)
    {
        var count = await source.CountAsync(cancellationtoken);
        var items = await source
            .Skip((pageIndex - 1) * pageNumber)
            .Take(pageNumber)
            .ToListAsync(cancellationtoken);

        return new PagedList<T>(items, count, pageIndex, pageNumber);
    }
    
    public static Task<PagedList<T>> ToPagedList(IEnumerable<T> source, int pageIndex, int pageNumber)
    {
        var count = source.Count();
        var items = source
            .Skip((pageIndex - 1) * pageNumber)
            .Take(pageNumber)
            .ToList();

        return Task.FromResult(new PagedList<T>(items, count, pageIndex, pageNumber));
    }

    private Metadata _metadata { get; }

    public Metadata Metadata => _metadata;
}