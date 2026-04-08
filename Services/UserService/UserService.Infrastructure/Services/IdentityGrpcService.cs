using Grpc.Core;
using IdentityGrpcService.Grpc;
using MapsterMapper;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Infrastructure.Services;

public class IdentityGrpcService : IIdentityService
{
    private readonly global::IdentityGrpcService.Grpc.IdentityGrpcService.IdentityGrpcServiceClient _client;
    private readonly IMapper _mapper;

    public IdentityGrpcService(
        global::IdentityGrpcService.Grpc.IdentityGrpcService.IdentityGrpcServiceClient client,
        IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<Guid> RegisterIdentityGuestAsync(
        RegisterIdentityGuestRequest request,
        CancellationToken cancellationToken)
    {
        var callOptions = new CallOptions(cancellationToken: cancellationToken);

        var registerIdentityGuestGrpcResponse = await _client.RegisterIdentityGuestAsync(
            _mapper.Map<RegisterIdentityGuestGrpcRequest>(request),
            callOptions);

        return Guid.Parse(registerIdentityGuestGrpcResponse.Id);
    }

    public async Task RemoveIdentityByIdAsync(
        Guid identityUserId,
        CancellationToken cancellationToken)
    {
        var callOptions = new CallOptions(cancellationToken: cancellationToken);

        await _client.RemoveIdentityByIdAsync(
            _mapper.Map<RemoveIdentityByIdGrpcRequest>(identityUserId),
            callOptions);
    }
}