using Microsoft.AspNetCore.Mvc;

namespace PropertyService.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;
        
        return Ok("Hello World");
    }
}