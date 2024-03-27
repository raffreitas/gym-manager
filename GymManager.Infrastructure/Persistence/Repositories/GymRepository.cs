using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Persistence.Repositories;
public class GymRepository : IGymRepository
{
    private readonly GymManagerDbContext _context;

    public GymRepository(GymManagerDbContext context)
        => _context = context;

    public async Task AddAsync(Gym gym, CancellationToken cancellationToken)
    {
        await _context.Gyms.AddAsync(gym, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Gym?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var gym = await _context
            .Gyms
            .SingleOrDefaultAsync(g => g.Id.Equals(id), cancellationToken);

        return gym;
    }

    public async Task<IList<Gym>> SearchMany(string name, CancellationToken cancellationToken)
    {
        var gyms = await _context.Gyms
             .AsNoTracking()
             .Where(x => x.Title.Contains(name))
             .ToListAsync(cancellationToken: cancellationToken);

        return gyms;
    }

    public async Task<IList<Gym>> SearchManyNearbyAsync(decimal latitude, decimal longitude, CancellationToken cancellationToken)
    {
        var distanceInKm = 10;

        var gyms = await _context.Gyms
            .FromSql(@$"
                SELECT 
                    [Id],
                    [Title],
                    [Description],
                    [Phone],
                    [Latitude],
                    [Longitude]
                FROM [Gym]
                WHERE (6371 * ACOS(COS(RADIANS({latitude})) * COS(RADIANS([Latitude])) * COS(RADIANS([Longitude]) - RADIANS({longitude})) + SIN(RADIANS({latitude})) * SIN(RADIANS(latitude)))) <= {distanceInKm}")
            .ToListAsync(cancellationToken: cancellationToken);

        return gyms;
    }
}
