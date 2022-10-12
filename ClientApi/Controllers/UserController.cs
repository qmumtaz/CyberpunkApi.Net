using ClientApi.Dtos;
using ClientApi.Services;
using ClientApi.Services.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ClientApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPostService _postService;
    private readonly IHashing _hashing;

    public UserController(IUserService userService, IPostService postService, IHashing hashing)
    {
        _userService = userService;
        _postService = postService;
        _hashing = hashing;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var user = _userService.GetUserById(id);

        return user is not null ? Ok(user) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, UserDto user)
    {
        try
        {
            
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = _hashing.HashPassword(user.Password);
                }
            

            var olduser = _userService.GetUserById(id);

            if (user is not null)
            {
                olduser.Username = user.Username;
                olduser.Password = user.Password;
                olduser.Email = user.Email;
                await _userService.Update(olduser);
                return Ok();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var user = _userService.GetUserById(id);

            if (user is not null)
            {
                _postService.Delete(id);
                await _userService.Delete(id);
                return Ok();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

        return BadRequest();
    }
}
