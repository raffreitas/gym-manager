using GymManager.Core.Repositories;

using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Persistence.Repositories;
public class CheckInRepository : ICheckInRepository
{
    private readonly GymManagerDbContext _context;

    public CheckInRepository(GymManagerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountByUserAsync(Guid userId, CancellationToken cancellationToken)
        => await _context.CheckIns
            .CountAsync(x => x.UserId.Equals(userId), cancellationToken: cancellationToken);

}
