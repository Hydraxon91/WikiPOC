using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using wiki_backend.Contracts;
using wiki_backend.Services.Authentication;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    [EnableRateLimiting("LoginPolicy")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.RegisterAsync(request.Email, request.Username, request.Password, "User");
        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }
        
        return CreatedAtAction(nameof(Register), new RegistrationResponse(result.Email, result.UserName));
    }

    [HttpPost("Login")]
    [EnableRateLimiting("LoginPolicy")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _authService.LoginAsync(request.Email, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        return Ok(new AuthResponse(result.Email, result.UserName, result.Token));
    }
    
    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }
}