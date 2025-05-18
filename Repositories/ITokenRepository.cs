using Microsoft.AspNetCore.Identity;

namespace Bimbrownik_API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
