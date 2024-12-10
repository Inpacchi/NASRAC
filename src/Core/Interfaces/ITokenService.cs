using NASRAC.Models.WebApp.Entities;

namespace Core.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}