using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly LoginService _loginService;
    private readonly IConfiguration _configuration;

    public LoginController(IUserService userService, LoginService loginService, IConfiguration configuration)
    {
        _userService = userService;
        _loginService = loginService;
        _configuration = configuration;
    }

    [HttpPost]
    public ActionResult Login([FromBody]UserLogin userLogin)
    {
        try
        {
            User user = _userService.Get(userLogin);

            string tokenString = _loginService.CreateJwt(_configuration, user);
            return Ok(new LoginResponse {Token = tokenString, Username = user.Username, Coins = user.Coins});
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    [Route("/{username}")]
    public ActionResult TryLogin(string username)
    {
        try
        {
            User user = _userService.GetByUsername(username);
            return Ok(new LoginResponse {Token = Request.Headers["Authorization"], Username = user.Username, Coins = user.Coins});
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}