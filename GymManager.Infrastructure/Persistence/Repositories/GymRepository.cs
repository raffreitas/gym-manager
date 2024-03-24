using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using Microsoft.EntityFrameworkCore;

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

    public async Task<IList<Gym>> SearchMany(string name, CancellationToken cancellationToken)
    {
        var gyms = await _context.Gyms
             .AsNoTracking()
             .Where(x => x.Title.Contains(name))
             .ToListAsync();

        return gyms;
    }
}
