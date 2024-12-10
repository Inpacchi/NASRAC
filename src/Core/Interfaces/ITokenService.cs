using NASRAC.Core.Entities.WebApp;

namespace NASRAC.Core.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}