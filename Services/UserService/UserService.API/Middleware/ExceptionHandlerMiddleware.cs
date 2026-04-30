using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Grpc.Core;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Exceptions;

namespace UserService.API.Middleware;

public class ExceptionHandlerMiddleware : IExceptionHandler
{
    private const string UnknownErrorMessage = "An unexpected error occurred.";
    private const string InternalServiceErrorMessage =
        "An unexpected error occurred while communicating with an internal service.";

    private readonly IProblemDetailsService _problemDetailsService;

    public ExceptionHandlerMiddleware(IProblemDetailsService problemDetailsService) =>
        _problemDetailsService = problemDetailsService;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        var (statusCode, response) = exception switch
        {
            ValidationDomainException or ValidationException => (StatusCodes.Status400BadRequest, exception.Message),
            //Business grpc exceptions should be handled before reaching this middleware.
            RpcException rpcEx => (MapUnhandledGrpcExceptionsToStatusCodes(rpcEx), InternalServiceErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, UnknownErrorMessage)
        };

        httpContext.Response.StatusCode = statusCode;

        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Detail = response,
            }
        });
    }

    private static int MapUnhandledGrpcExceptionsToStatusCodes(RpcException ex) =>
        ex.StatusCode switch
        {
            StatusCode.Unauthenticated => StatusCodes.Status401Unauthorized,
            StatusCode.PermissionDenied => StatusCodes.Status403Forbidden,
            StatusCode.Internal => StatusCodes.Status502BadGateway,
            StatusCode.Unavailable => StatusCodes.Status503ServiceUnavailable,
            StatusCode.DeadlineExceeded => StatusCodes.Status504GatewayTimeout,
            _ => StatusCodes.Status502BadGateway
        };
}