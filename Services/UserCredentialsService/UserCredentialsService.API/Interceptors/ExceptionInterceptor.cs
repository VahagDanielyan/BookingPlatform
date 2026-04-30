using Grpc.Core;
using Grpc.Core.Interceptors;
using Shared.Domain.Exceptions;

namespace UserCredentialsService.API.Interceptors;

public class ExceptionInterceptor : Interceptor
{
    private readonly IHostEnvironment _hostEnvironment;

    public ExceptionInterceptor(IHostEnvironment hostEnvironment) => _hostEnvironment = hostEnvironment;

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception exception)
        {
            switch (exception)
            {
                case ValidationDomainException validationDomainException:
                    throw new RpcException(
                        new Status(StatusCode.InvalidArgument, validationDomainException.Message));
                case ConflictDomainException conflictDomainException:
                    throw new RpcException(
                        new Status(StatusCode.FailedPrecondition, conflictDomainException.Message));
                default:
                    var message = _hostEnvironment.IsDevelopment()
                        ? "Internal server error | StackTrace: " + exception
                        : "Internal server error";
                    throw new RpcException(
                        new Status(StatusCode.Internal, message));
            }
        }
    }
}