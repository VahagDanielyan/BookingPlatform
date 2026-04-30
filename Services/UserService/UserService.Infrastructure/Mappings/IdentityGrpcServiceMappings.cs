using Mapster;
using UserCredentialsService.Grpc;

namespace UserService.Infrastructure.Mappings;

public class IdentityGrpcServiceMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, RemoveUserCredentialsByIdGrpcRequest>()
            .Map(dest => dest.Id, src => src.ToString());
    }
}