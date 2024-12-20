namespace MinimalApi.Infrastructure.Shared;

public class ApiResult<T>
{
    public T Data { get; set; }
    public bool IsSuccessed { get; set; }
    public string Message { get; set; }

    public ApiResult(bool isSuccessed, string message = null)
    {
        IsSuccessed = isSuccessed;
        Message = message;
    }

    public ApiResult(T data, bool isSuccessed, string message = null)
    {
        Data = data;
        IsSuccessed = isSuccessed;
        Message = message;
    }

    public ApiResult(T Data, bool isSuccesed)
    {
        Data = Data;
        IsSuccessed = isSuccesed;
    }
}