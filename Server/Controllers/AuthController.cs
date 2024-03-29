using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecipePlanner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
    {
        var response = await _authService.Register(new User { Name = request.Name, Email = request.Email}, request.Password);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
    {
        var response = await _authService.Login(request.Email, request.Password);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
    
    [HttpPost("change-password"), Authorize]
    public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _authService.ChangePassword(Guid.Parse(userId!), newPassword);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}