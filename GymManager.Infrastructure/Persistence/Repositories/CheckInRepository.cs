using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Persistence.Repositories;
public class CheckInRepository : ICheckInRepository
{
    private readonly GymManagerDbContext _context;

    public CheckInRepository(GymManagerDbContext context)
        => _context = context;


    public async Task AddAsync(CheckIn checkIn)
    {
        await _context.AddAsync(checkIn);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountByUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        var count = await _context
            .CheckIns
            .CountAsync(x => x.UserId.Equals(userId), cancellationToken: cancellationToken);

        return count;
    }

    public async Task<CheckIn?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var checkIn = await _context.CheckIns.SingleOrDefaultAsync(g => g.Id.Equals(id), cancellationToken);
        return checkIn;
    }

    public async Task<CheckIn?> GetByUserIdOnDate(Guid userId, DateTime date, CancellationToken cancellationToken)
    {
        var checkIn = await _context
            .CheckIns
            .SingleOrDefaultAsync(c => c.UserId.Equals(userId) && c.CreatedAt.Date.Equals(date.Date), cancellationToken);

        return checkIn;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
