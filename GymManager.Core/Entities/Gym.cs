namespace GymManager.Core.Entities;
public class Gym : BaseEntity
{
    protected Gym() { }

    public Gym(string title, decimal latitude, decimal longitude)
    {
        Title = title;
        Latitude = latitude;
        Longitude = longitude;

        CheckIns = [];
    }

    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public string? Phone { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }

    public IList<CheckIn> CheckIns { get; private set; } = [];
}
