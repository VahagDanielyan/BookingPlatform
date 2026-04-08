namespace IdentityService.Application.Exceptions;

public abstract class BaseBusinessException : Exception
{
    public BaseBusinessException()
    {
    }

    public BaseBusinessException(string message) : base(message)
    {
    }
}