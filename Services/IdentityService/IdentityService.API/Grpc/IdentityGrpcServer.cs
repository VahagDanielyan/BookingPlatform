using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using IdentityGrpcService.Grpc;
using IdentityService.Application.Handlers.IdentityUsers.Commands.RegisterIdentityUserCommand;
using IdentityService.Application.Handlers.IdentityUsers.Commands.RemoveIdentityUserByIdCommand;
using MapsterMapper;
using MediatR;

namespace IdentityService.API.Grpc;

public class IdentityGrpcServer : IdentityGrpcService.Grpc.IdentityGrpcService.IdentityGrpcServiceBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public IdentityGrpcServer(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async Task<RegisterIdentityGuestGrpcResponse> RegisterIdentityGuest(
        RegisterIdentityGuestGrpcRequest request,
        ServerCallContext context)
    {
        var identityUserId = await _mediator.Send(_mapper.Map<RegisterIdentityUserCommand>(request), context.CancellationToken);

        return _mapper.Map<RegisterIdentityGuestGrpcResponse>(identityUserId);
    }

    public override async Task<Empty> RemoveIdentityById(RemoveIdentityByIdGrpcRequest request,
        ServerCallContext context)
    {
        await _mediator.Send(_mapper.Map<RemoveIdentityUserByIdCommand>(request), context.CancellationToken);

        return new Empty();
    }
}