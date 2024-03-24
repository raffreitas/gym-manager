using GymManager.Core.Enums;

namespace GymManager.Core.Services;
public interface IAuthService
{
    string HashPassword(string plainPassword);
    string GenerateToken(Guid id, Role role);
}
