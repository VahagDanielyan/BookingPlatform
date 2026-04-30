using Mapster;
using UserService.API.DTOs;
using UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

namespace UserService.API.Mappings;

public class DtoMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterGuestRequest, RegisterGuestCommand>();
    }
}