using System.Text.RegularExpressions;

namespace UserService.Domain.Common;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[A-Za-z]+$")]
    public static partial Regex LatinOnly();

    [GeneratedRegex(@"^[A-Za-z]+(?: [A-Za-z]+)*$")]
    public static partial Regex LatinOnlyWithSingleSpaces();

    [GeneratedRegex(@"[^\d]")]
    public static partial Regex NonDigitCharacters();
}