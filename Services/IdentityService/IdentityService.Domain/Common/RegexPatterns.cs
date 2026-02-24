using System.Text.RegularExpressions;

namespace IdentityService.Domain.Common;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[A-Za-z]+(?: [A-Za-z]+)*$")]
    public static partial Regex ValidEmailFormat();
}