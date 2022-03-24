using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPut]
    public ActionResult UpdateCoins([FromBody] (string username, string coins) v)
    {
        try
        {
            string updateUserCoins = _userService.UpdateUserCoins(v.username, v.coins);
            return Ok(updateUserCoins);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}