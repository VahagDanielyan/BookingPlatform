namespace Shared.Domain.Exceptions;

public class ConflictDomainException(string message) : BaseDomainException(message);