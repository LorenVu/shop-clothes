namespace Clothes.Infrastructure.Shared.Responses;

public class ApiResult<T>
{
    public T? Data { get; set; }
    public bool IsSuccessed { get; set; }
    public string? Message { get; set; }

    protected ApiResult(bool isSuccessed, string? message = null)
    {
        IsSuccessed = isSuccessed;
        Message = message;
    }

    protected ApiResult(T data, bool isSuccessed, string? message = null)
    {
        Data = data;
        IsSuccessed = isSuccessed;
        Message = message;
    }

    protected ApiResult(T data, bool isSuccesed)
    {
        Data = data;
        IsSuccessed = isSuccesed;
    }
}