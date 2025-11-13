using Microsoft.AspNetCore.Identity;

namespace Jobseer.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
