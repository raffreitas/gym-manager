using MediatR;

namespace GymManager.Application.Commands.CreateGym;
public class CreateGymCommand : IRequest
{
    public CreateGymCommand(string title, string? description, string? phone, decimal latitude, decimal longitude)
    {
        Title = title;
        Description = description;
        Phone = phone;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string? Phone { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
}
