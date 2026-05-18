using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartProducts.Infrastructure.Authentication;

namespace SmartProducts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly RefreshTokenService _refreshTokenService;

    public AuthController(
        JwtService jwtService,
        RefreshTokenService refreshTokenService)
    {
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login()
    {
        // Usuario demo para la prueba técnica.
        var token = _jwtService.GenerateToken("admin");
        var refreshToken = _refreshTokenService.GenerateRefreshToken();

        return Ok(new
        {
            accessToken = token,
            refreshToken = refreshToken
        });
    }
}