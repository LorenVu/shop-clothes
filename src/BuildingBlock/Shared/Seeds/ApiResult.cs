namespace BuildingBlock.Shared.Seeds;

public class ApiResult<T>
{
    public T? Data { get; set; }
    public bool IsSuccessed { get; init; }
    public string? Message { get; set; }

    protected ApiResult(bool isSuccessed, string? message = null)
    {
        Message = message;
        IsSuccessed = isSuccessed;
    }

    protected ApiResult(T data, bool isSuccessed, string? message = null)
    {
        Data = data;
        Message = message;
        IsSuccessed = isSuccessed;
    }

    protected ApiResult(T data, string? message = null)
    {
        Data = data;
        Message = message;
    }
}