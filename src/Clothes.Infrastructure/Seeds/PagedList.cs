using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Seeds;

public class PagedList<T> : List<T>
{

    public PagedList(IEnumerable<T> items, long totalItems, int pageIndex, int pageSize)
    {
        _metadata = new Metadata
        {
            TotalItems = totalItems,
            PageSize = pageSize,
            CurrentPage = pageIndex,
            //TotalPages = (int) Math.Ceiling(totalItems / (double)pageSize)
        };

        AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageIndex, int pageNumber)
    {
        var count = await source.CountAsync();
        var items = await source
            .Skip((pageIndex - 1) * pageNumber)
            .Take(pageNumber)
            .ToListAsync();

        return new PagedList<T>(items, count, pageIndex, pageNumber);
    }

    private Metadata _metadata { get; }

    public Metadata Metadata => _metadata;
}