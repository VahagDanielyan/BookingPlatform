using IdentityService.Domain.Enums;

namespace IdentityService.Application.DTOs;

public record AddIdentityUserRequest(string Email, string Phone, string PasswordHash, IdentityRole IdentityRole);