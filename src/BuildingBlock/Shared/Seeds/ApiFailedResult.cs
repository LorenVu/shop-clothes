using BuildingBlock.Shared.Configs;
using Clothes.Domain.Extensions;

namespace BuildingBlock.Shared.Seeds;

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

    private static readonly Lazy<ApiFailedResult<T>> Lazy = new(() => new ApiFailedResult<T>());

    public static ApiFailedResult<T> Instance => Lazy.Value;

    public ApiFailedResult<T> WithMessage(CodeResponseMessage codeResponseMessage, string message = "")
    {
        Instance.Message = GetMessage(message, codeResponseMessage);
        return Instance;
    }
    
    #region Method

    private static string GetMessage(string? input, CodeResponseMessage codeResponseMessage)
    {
        return string.IsNullOrEmpty(input) 
            ? ResponseMessageConfigs.GetMessage(codeMessage: codeResponseMessage) 
            : input.RemoveSpaceCharacter();
    }
    
    #endregion
}