using MediatR;

namespace GymManager.Application.Commands.CreateCheckIn;
public class CreateCheckInCommand : IRequest
{
    public CreateCheckInCommand(Guid userId, Guid gymId, decimal userLatitude, decimal userLongitude)
    {
        UserId = userId;
        GymId = gymId;
        UserLatitude = userLatitude;
        UserLongitude = userLongitude;
    }

    public Guid UserId { get; private set; }
    public Guid GymId { get; private set; }
    public decimal UserLatitude { get; private set; }
    public decimal UserLongitude { get; private set; }
}
