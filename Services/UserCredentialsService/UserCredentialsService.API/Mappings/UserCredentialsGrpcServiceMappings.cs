using Mapster;
using UserCredentialsService.Grpc;

namespace UserCredentialsService.API.Mappings;

public class UserCredentialsGrpcServiceMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, RegisterUserCredentialsGrpcResponse>()
            .Map(dest => dest.Id, src => src);
    }
}