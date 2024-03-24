using GymManager.Core.Enums;

namespace GymManager.Application.ViewModels;
public class UserProfileViewModel
{
    public UserProfileViewModel(Guid id, string name, string email, Role role, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
