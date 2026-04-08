using IdentityGrpcService.Grpc;
using IdentityService.Application.Handlers.IdentityUsers.Commands.RegisterIdentityUserCommand;
using IdentityService.Application.Handlers.IdentityUsers.Commands.RemoveIdentityUserByIdCommand;
using IdentityService.Domain.Enums;
using Mapster;

namespace IdentityService.API.Mappings;

public class ApiRequestsAndCommandsMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterIdentityGuestGrpcRequest, RegisterIdentityUserCommand>()
            .Map(dest => dest.Role, src => IdentityRole.Guest);
        config.NewConfig<Guid, RegisterIdentityGuestGrpcResponse>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<RemoveIdentityByIdGrpcRequest, RemoveIdentityUserByIdCommand>();
    }
}