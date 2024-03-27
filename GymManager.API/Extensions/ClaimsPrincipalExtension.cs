using System.Security.Claims;

using Microsoft.IdentityModel.JsonWebTokens;

namespace GymManager.API.Extensions;

public static class ClaimsPrincipalExtension
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        var sub = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (sub is null)
            throw new ArgumentException(nameof(JwtRegisteredClaimNames.Sub));

        return new Guid(sub);
    }
}
