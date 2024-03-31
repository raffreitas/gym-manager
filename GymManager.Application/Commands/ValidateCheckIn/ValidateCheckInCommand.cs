using MediatR;

namespace GymManager.Application.Commands.ValidateCheckIn;
public class ValidateCheckInCommand : IRequest
{
    public ValidateCheckInCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
