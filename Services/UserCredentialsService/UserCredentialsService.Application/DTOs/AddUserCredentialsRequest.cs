using Shared.Domain.Enums;

namespace UserCredentialService.Application.DTOs;

public record AddUserCredentialsRequest(string Email, string Phone, string PasswordHash, UserRole UserRole);