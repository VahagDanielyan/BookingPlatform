namespace Shared.Domain.Exceptions;

public class ValidationDomainException(string message) : BaseDomainException(message);