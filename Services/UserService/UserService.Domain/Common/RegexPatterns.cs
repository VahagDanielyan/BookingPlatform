using System.Text.RegularExpressions;

namespace UserService.Domain.Common;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[A-Za-z]+$")]
    public static partial Regex LatinOnly();
}