using NASRAC.Core.Entities.WebApp;

namespace NASRAC.API.Services.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}