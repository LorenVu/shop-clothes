namespace Clothes.Infrastructure.Shared.Requests;

public class PagingRequestParameters
{
    private const int maxPageSize = 200;
    private int _pageIndex = 1;
    private int _pageSize = 20;

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value > 0)
                _pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
}