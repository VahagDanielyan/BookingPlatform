using Shared.Domain.Enums;

namespace UserService.Application.DTOs;

public record RegisterUserCredentailsRequest(string Email, string Phone, string Password, UserRole UserRole);