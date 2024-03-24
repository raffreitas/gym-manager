using System.Security.Cryptography;
using System.Text;

using GymManager.Core.Services;

namespace GymManager.Infrastructure.AuthServices;
public class AuthService : IAuthService
{
    public string HashPassword(string plainPassword)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(plainPassword));

        StringBuilder sb = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }

        return sb.ToString();
    }
}
