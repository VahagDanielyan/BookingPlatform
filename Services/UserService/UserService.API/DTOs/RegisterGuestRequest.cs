namespace UserService.API.DTOs;

public record RegisterGuestRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Password
);