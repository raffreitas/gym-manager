using GymManager.Core.Entities;

namespace GymManager.Core.Repositories;
public interface ICheckInRepository
{
    Task<int> CountByUserAsync(Guid userId, CancellationToken cancellationToken);
    Task<CheckIn?> GetByUserIdOnDate(Guid userId, DateTime date, CancellationToken cancellationToken);
    Task AddAsync(CheckIn checkIn);
}
