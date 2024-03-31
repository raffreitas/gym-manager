namespace GymManager.Core.Entities;
public class CheckIn : BaseEntity
{
    protected CheckIn() { }

    public CheckIn(Gym gym, User user)
    {
        Gym = gym;
        User = user;
        CreatedAt = DateTime.UtcNow;
    }

    public DateTime CreatedAt { get; private set; }
    public DateTime? ValidatedAt { get; private set; }

    public Guid GymId { get; private set; }
    public Gym Gym { get; private set; } = null!;

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public void Validate()
    {
        ValidatedAt = DateTime.UtcNow;
    }
}
