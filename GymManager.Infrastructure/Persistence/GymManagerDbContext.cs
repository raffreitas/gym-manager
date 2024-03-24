using System.Reflection;

using GymManager.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Persistence;
public class GymManagerDbContext : DbContext
{
    public GymManagerDbContext(DbContextOptions<GymManagerDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Gym> Gyms { get; set; } = null!;
    public DbSet<CheckIn> CheckIns { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
