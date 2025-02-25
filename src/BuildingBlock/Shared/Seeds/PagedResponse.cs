namespace BuildingBlock.Shared.Seeds;

public class PagedResponse<T>(PagedList<T> pagedList)
{
    public IEnumerable<T> Items { get; set; } = pagedList;
    public Metadata Metadata { get; set; } = pagedList.Metadata;
}