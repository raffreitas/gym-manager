using GymManager.Core.Entities;

namespace GymManager.Core.Repositories;
public interface IGymRepository
{
    Task AddAsync(Gym gym, CancellationToken cancellationToken);
    Task<IList<Gym>> SearchMany(string name, CancellationToken cancellationToken);
}
