using GymManager.Core.Entities;
using GymManager.Core.Repositories;

namespace GymManager.Infrastructure.Persistence.Repositories;
public class GymRepository : IGymRepository
{
    private readonly GymManagerDbContext _context;
    public GymRepository(GymManagerDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Gym gym, CancellationToken cancellationToken)
    {
        await _context.Gyms.AddAsync(gym, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
