using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly GymManagerDbContext _context;

    public UserRepository(GymManagerDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        return user;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
