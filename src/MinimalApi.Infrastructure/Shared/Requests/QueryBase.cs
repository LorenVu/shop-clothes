using System.Text.Json.Serialization;

namespace MinimalApi.Infrastructure.Shared.Requests;

public class QueryPagingBase : PagingRequestParameters
{
    
}

public abstract class QueryBase<TFilter, TOrder> : PagingRequestParameters
where TFilter : FilterCondition
where TOrder : OrderCondition
{
    
    public List<TFilter>? Filters { get; set; }
    
    public List<TOrder>? Orders { get; set; }
}