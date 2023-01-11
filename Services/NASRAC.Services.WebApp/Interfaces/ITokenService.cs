using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Services.WebApp.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}