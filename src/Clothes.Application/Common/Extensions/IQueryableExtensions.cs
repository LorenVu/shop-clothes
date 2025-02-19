using Clothes.Infrastructure.Shared.Requests;

namespace Clothes.Application.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Filtering<T>(this IQueryable<T> query, List<FilterCondition> filters)
    {
        // foreach (var filter in filters)
        // {
        //     var condition = $"{filter.Field} {GetOperator(filter.Operator)} @0";
        //     query = query.Where(condition, filter.Value);
        // }
        return query;
    }

    public static IQueryable<T> Ordering<T>(this IQueryable<T> query, IEnumerable<OrderCondition> sorts)
    {
        // foreach (var sort in sorts)
        // {
        //     query.OrderBy($"{sort.Field} {sort.Direction}");
        // }

        return query;
    }


    private static string GetOperator(string operatorKey)
    {
        return operatorKey switch
        {
            "equals" => "==",
            "notEquals" => "!=",
            "greaterThan" => ">",
            "greaterThanOrEqual" => ">=",
            "lessThan" => "<",
            "lessThanOrEqual" => "<=",
            "contains" => ".Contains",
            _ => throw new NotSupportedException($"Operator {operatorKey} is not supported"),
        };
    }
}