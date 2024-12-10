using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NASRAC.API.Controllers.Base;
using NASRAC.API.Game.DTOs;
using NASRAC.Core.Entities.WebApp;
using NASRAC.Core.Interfaces;

namespace NASRAC.API.Controllers;

public class AccountController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    ITokenService tokenService)
    : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is already taken");

        var user = new AppUser()
        {
            UserName = registerDto.Username.ToLower(),
            Email = registerDto.Email
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(user =>
            user.UserName.ToLower() == loginDto.Username.ToLower());

        if (user == null) return Unauthorized("Invalid username");

        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized();

        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await userManager.Users.AnyAsync(user => user.UserName == username.ToLower());
    }
}