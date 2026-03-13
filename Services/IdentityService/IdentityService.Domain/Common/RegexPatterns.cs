using System.Text.RegularExpressions;

namespace IdentityService.Domain.Common;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[A-Za-z]+(?: [A-Za-z]+)*$")]
    public static partial Regex ValidEmailFormat();
    
    // E.164 phone format without "+"
    [GeneratedRegex(@"^[1-9]\d{6,14}$")]
    public static partial Regex InternationalPhone();
}