using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Commands.ValidateCheckIn;
public class ValidateCheckInCommandHandler : IRequestHandler<ValidateCheckInCommand>
{
    private readonly ICheckInRepository _checkInRepository;

    public ValidateCheckInCommandHandler(ICheckInRepository checkInRepository)
    {
        _checkInRepository = checkInRepository;
    }

    public async Task Handle(ValidateCheckInCommand request, CancellationToken cancellationToken)
    {
        var gym = await _checkInRepository.GetByIdAsync(request.Id, cancellationToken);

        if (gym is null)
            throw new ResourceNotFoundException();

        gym.Validate();
    }
}
