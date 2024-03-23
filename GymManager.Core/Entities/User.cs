using GymManager.Core.Enums;

namespace GymManager.Core.Entities;
public class User : BaseEntity
{
    protected User() { }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;

        Role = Role.Member;
        CreatedAt = DateTime.UtcNow;
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IList<CheckIn> CheckIns { get; private set; } = [];

}
