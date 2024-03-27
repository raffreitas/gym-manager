using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;
using GymManager.Core.ValueObjects;

using MediatR;

namespace GymManager.Application.Commands.CreateCheckIn;
public class CreateCheckInCommandHandler : IRequestHandler<CreateCheckInCommand>
{
    private readonly IGymRepository _gymRepository;
    private readonly ICheckInRepository _checkInRepository;
    private readonly IUserRepository _userRepository;

    private const int MAX_DISTANCE_IN_KILOMETERS = 10;

    public CreateCheckInCommandHandler(IGymRepository gymRepository, ICheckInRepository checkInRepository, IUserRepository userRepository)
    {
        _gymRepository = gymRepository;
        _checkInRepository = checkInRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(CreateCheckInCommand request, CancellationToken cancellationToken)
    {
        var gym = await _gymRepository.GetByIdAsync(request.GymId, cancellationToken);

        if (gym is null)
            throw new ResourceNotFoundException();

        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            throw new ResourceNotFoundException();

        var fromCoordinate = new Coordinate((double)request.UserLatitude, (double)request.UserLongitude);
        var toCoordinate = new Coordinate((double)gym.Latitude, (double)gym.Longitude);

        var distance = CalculateDistanceBetweenCoordinates(fromCoordinate, toCoordinate);

        if (distance > MAX_DISTANCE_IN_KILOMETERS)
            throw new Exception("Não foi possivel fazer check-in nesta academia");

        var checkInOnSameDay = await _checkInRepository.GetByUserIdOnDate(request.UserId, DateTime.UtcNow, cancellationToken);

        if (checkInOnSameDay is not null)
            throw new Exception("Não é possivel fazer mais de um check-in no mesmo dia");

        var checkIn = new CheckIn(gym, user);

        await _checkInRepository.AddAsync(checkIn);
    }

    // Haversine formula
    private static double CalculateDistanceBetweenCoordinates(Coordinate from, Coordinate to)
    {
        if (from.Latitude.Equals(to.Latitude) && from.Longitude.Equals(to.Longitude))
            return 0;

        const double r = 6372.8; // In Killometers

        var dLat = (to.Latitude - from.Latitude) * (Math.PI / 180);
        var dLon = (to.Longitude - from.Longitude) * (Math.PI / 180);
        var fromRad = from.Latitude * (Math.PI / 180);
        var toRad = to.Latitude * (Math.PI / 180);

        var a = Math.Pow(Math.Sin(dLat / 2), 2) +
                Math.Pow(Math.Sin(dLon / 2), 2) *
                Math.Cos(fromRad) * Math.Cos(toRad);

        var c = 2 * Math.Asin(Math.Sqrt(a));

        return r * c;
    }
}