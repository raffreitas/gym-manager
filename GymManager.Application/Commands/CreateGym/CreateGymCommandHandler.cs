using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Commands.CreateGym;
public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand>
{
    private readonly IGymRepository _gymRepository;

    public CreateGymCommandHandler(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }

    public async Task Handle(CreateGymCommand request, CancellationToken cancellationToken)
    {
        var gym = new Gym(request.Title, request.Latitude, request.Longitude, request.Description, request.Phone);

        await _gymRepository.AddAsync(gym, cancellationToken);
    }
}
