using GymManager.Core.Entities;

namespace GymManager.Core.Repositories;
public interface IGymRepository
{
    Task AddAsync(Gym gym, CancellationToken cancellationToken);
    Task<Gym?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Gym>> SearchManyAsync(string name, CancellationToken cancellationToken);
    Task<IList<Gym>> SearchManyNearbyAsync(decimal latitude, decimal longitude, CancellationToken cancellationToken);
}
