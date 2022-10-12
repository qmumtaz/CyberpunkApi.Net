using ClientApi.Dtos;
using ClientApi.Services;
using ClientApi.Services.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Auth : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IHashing _hashing;

    public Auth(IUserService userService, IHashing hashing)
    {
        _userService = userService;
        _hashing = hashing;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthLoginDto login)
    {
        var user = await _userService.GetUserByUsername(login.Username);

        if (user is null)
        {
            return BadRequest();
        }

        var verify = _hashing.ValidatePassword(login.Password, user.Password);

        if (!verify)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto register)
    {
        try
        {
            var passwordHash = _hashing.HashPassword(register.Password);

            await _userService.CreateUser(new User()
            {
                Username = register.Username,
                Password = passwordHash,
                Email = register.Email,
            });
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

        return Ok();
    }
}
