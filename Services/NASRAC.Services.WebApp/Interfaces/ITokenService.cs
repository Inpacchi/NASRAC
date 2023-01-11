using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Services.WebApp.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}