namespace GymManager.Core.Entities;
public class CheckIn : BaseEntity
{
    protected CheckIn() { }

    public CheckIn(Gym gym)
    {
        Gym = gym;
        CreatedAt = DateTime.UtcNow;
    }

    public DateTime CreatedAt { get; private set; }
    public DateTime? ValidatedAt { get; private set; }

    public Gym Gym { get; private set; } = null!;
}
