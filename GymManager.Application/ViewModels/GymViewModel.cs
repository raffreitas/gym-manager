namespace GymManager.Application.ViewModels;
public class GymViewModel
{
    public GymViewModel(string name, string? description, string? phone, decimal latitude, decimal longitude)
    {
        Name = name;
        Description = description;
        Phone = phone;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? Phone { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
}
