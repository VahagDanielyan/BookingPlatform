namespace UserService.Application.DTOs;

public record AddUserRequest(Guid IdentityUserId, string FirstName, string LastName);