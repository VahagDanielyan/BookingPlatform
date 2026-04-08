using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.API.DTOs;
using UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

namespace UserService.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SignupController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SignupController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterGuest(
        RegisterGuestRequest registerGuestRequest,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(_mapper.Map<RegisterGuestCommand>(registerGuestRequest), cancellationToken);

        return Ok();
    }
}