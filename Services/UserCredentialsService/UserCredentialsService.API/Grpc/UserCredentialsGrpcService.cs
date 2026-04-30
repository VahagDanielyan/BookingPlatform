using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MapsterMapper;
using MediatR;
using UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RegisterIdentityUserCommand;
using UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RemoveUserCredentialsByIdCommand;
using UserCredentialsService.Grpc;

namespace UserCredentialsService.API.Grpc;

public class UserCredentialsGrpcService : UserCredentialsService.Grpc.UserCredentialsService.UserCredentialsServiceBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
 
    public UserCredentialsGrpcService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async Task<RegisterUserCredentialsGrpcResponse> RegisterUserCredentials(
        RegisterUserCredentialsGrpcRequest request,
        ServerCallContext context)
    {
        var identityUserId =
            await _mediator.Send(_mapper.Map<RegisterUserCredentialsByIdCommand>(request), context.CancellationToken);
        
        return _mapper.Map<RegisterUserCredentialsGrpcResponse>(identityUserId);
    }

    public override async Task<Empty> RemoveUserCredentialsById(
        RemoveUserCredentialsByIdGrpcRequest request,
        ServerCallContext context)
    {
        await _mediator.Send(_mapper.Map<RemoveUserCredentialsByIdCommand>(request), context.CancellationToken);
        
        return new Empty();
    }
}