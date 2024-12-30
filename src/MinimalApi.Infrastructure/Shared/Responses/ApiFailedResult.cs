namespace MinimalApi.Infrastructure.Shared;

public class ApiFailedResult<T> : ApiResult<T>
{
    public ApiFailedResult(string? message = null) : base(false, message)
    {
    }

    public ApiFailedResult(T data, string? message = null) : base(data, false, message)
    {
    }

    public ApiFailedResult(T data) : base(data, false)
    {
    }

    private static readonly Lazy<ApiFailedResult<T>> lazy = new (() => new ApiFailedResult<T>());
    
    public static ApiFailedResult<T> Instance => lazy.Value;

    public ApiFailedResult<T> WithMessage(string message)
    {
        Instance.Message = message;
        return Instance;
    }
}