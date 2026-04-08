namespace IdentityService.Application.Exceptions.IdentityUserExceptions;

public class IdentityUserAlreadyExistsException(string message) : BaseBusinessException(message);