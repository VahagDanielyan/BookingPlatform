namespace UserService.Application.DTOs;

public record AddUserRequest(Guid UserCredentailsId, string FirstName, string LastName);