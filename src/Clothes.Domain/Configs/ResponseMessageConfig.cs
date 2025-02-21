namespace Clothes.Domain.Configs;

public sealed class ResponseMessageConfig
{
    public static Dictionary<string, string> Values { get; private set; } = [];
    
    public static string GetMessage(CodeResponseMessage codeMessage, params object[] args)
    {
        var code = ((int)codeMessage).ToString("D4");
        if (Values.TryGetValue(code, out string? message))
        {
            return args.Length > 0 ? string.Format(message, args) : message;
        }
        return "Không xác định";
    }
}

public enum CodeResponseMessage
{
    Successed = 0000,
    Failed = 0001,
    
    DataInValid = 3001,
    // WorkstationHasBeenAuthenticated = 3002,
    NotSystemAccessPermission = 3003,
    DataNotFound = 3004,
    SystemError = 3005,
    Timeout = 3006,
    SystemIsUpgrating = 3007,
    TokenInvalid = 3008,
    ValidationException = 3009,
    PathIsNotExist = 3010,
    TokenIsNull = 3011,
    MethodNotAllowed = 3012,
    DatabaseTimeout = 3013,
    ExcuteSqlQueryError = 3014,
    AccountNotExist = 4000,
    LoginFailedPasswordNotCorrect = 4001,
    AccountLocked = 4003,
}