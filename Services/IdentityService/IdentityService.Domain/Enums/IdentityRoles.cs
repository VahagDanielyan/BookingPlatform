namespace IdentityService.Domain.Enums;

[Flags]
public enum IdentityRoles
{
    None  = 0,
    User  = 1 << 0,
    Admin = 1 << 1
}