using Grpc.Core;
using MapsterMapper;
using UserCredentialsService.Grpc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Infrastructure.Services;

public class UserCredentialsGrpcService : IUserCredentialsService
{
    private readonly UserCredentialsService.Grpc.UserCredentialsService.UserCredentialsServiceClient _client;
    private readonly IMapper _mapper;

    public UserCredentialsGrpcService(
        global::UserCredentialsService.Grpc.UserCredentialsService.UserCredentialsServiceClient client,
        IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<Guid> RegisterUserCredentialsAsync(
        RegisterUserCredentailsRequest registerUserCredentialsRequest,
        CancellationToken cancellationToken)
    {
        var callOptions = new CallOptions(cancellationToken: cancellationToken);

        var registerIdentityGuestGrpcResponse = await _client.RegisterUserCredentialsAsync(
            _mapper.Map<RegisterUserCredentialsGrpcRequest>(registerUserCredentialsRequest),
            callOptions);

        return Guid.Parse(registerIdentityGuestGrpcResponse.Id);
    }

    public async Task RemoveUserCredentialsIdAsync(
        Guid Id,
        CancellationToken cancellationToken = default)
    {
        var callOptions = new CallOptions(cancellationToken: cancellationToken);

        await _client.RemoveUserCredentialsByIdAsync(
            _mapper.Map<RemoveUserCredentialsByIdGrpcRequest>(Id),
            callOptions);
    }
}