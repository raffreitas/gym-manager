using GymManager.Core.Entities;

namespace GymManager.Core.Repositories;
public interface ICheckInRepository
{
    Task<int> CountByUserAsync(Guid userId, CancellationToken cancellationToken);
    Task<CheckIn?> GetByUserIdOnDateAsync(Guid userId, DateTime date, CancellationToken cancellationToken);
    Task<CheckIn?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(CheckIn checkIn);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
