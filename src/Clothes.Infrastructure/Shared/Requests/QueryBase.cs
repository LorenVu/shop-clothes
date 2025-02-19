using System.Text.Json.Serialization;

namespace Clothes.Infrastructure.Shared.Requests;

public class QueryPagingBase : PagingRequestParameters;

public abstract class QueryBase<TFilter, TOrder> : PagingRequestParameters
where TFilter : FilterCondition
where TOrder : OrderCondition
{
    public TFilter Filter { get; private set; }

    public TOrder Order { get; private set; }
}