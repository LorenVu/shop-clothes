namespace BuildingBlock.Shared.Configs;

public static class SystemGlobalConfigs
{
    #region PostgresqlConnectionString

    private static string? _postgresqlConnectionString;

    public static string? PostgresqlConnectionString
    {
        get => _postgresqlConnectionString;
        set => SetPostgresqlConnectionString(value);
    }

    private static void SetPostgresqlConnectionString(string? value)
    {
        if (!string.IsNullOrEmpty(_postgresqlConnectionString))
            throw new InvalidOperationException();

        if (string.IsNullOrEmpty(_postgresqlConnectionString) && !string.IsNullOrEmpty(value))
            _postgresqlConnectionString = value;
    }

    #endregion

    #region IsDebug

    private static bool? _isDebug;

    /// <summary>
    /// Define the execution environment: <br/>
    /// true - debug (dev/test environment) <br/>
    /// false - non-debug <br/>
    /// </summary>
    public static bool IsDebug
    {
        get => _isDebug ?? false;
        set => SetIsDebug(value);
    }

    private static void SetIsDebug(bool value)
    {
        if (_isDebug != null)
            throw new InvalidOperationException();

        _isDebug ??= value;
    }

    #endregion

    public const string Masked = "*** Masked ***";
}