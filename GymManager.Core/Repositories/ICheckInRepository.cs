namespace GymManager.Core.Repositories;
public interface ICheckInRepository
{
    Task<int> CountByUserAsync(Guid userId, CancellationToken cancellationToken);
}
