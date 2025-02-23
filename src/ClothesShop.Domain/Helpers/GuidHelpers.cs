using System.Text.RegularExpressions;

namespace MinimalApi.Domain.Helpers;

public partial class GuidHelpers
{
    [GeneratedRegex("^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$")]
    private static partial Regex GuidValidatorRegex();
}