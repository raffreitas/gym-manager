namespace GymManager.Core.Services;
public interface IAuthService
{
    string HashPassword(string plainPassword);
}
