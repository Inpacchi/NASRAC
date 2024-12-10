using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.WebApp.Entities;
using Data.DAL;

namespace NASRAC.API.Game.Controllers;

public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    // api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // api/users/{id:int}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}