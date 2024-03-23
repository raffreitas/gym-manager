using GymManager.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Persistence.Configurations;
public class CheckInConfiguration : IEntityTypeConfiguration<CheckIn>
{
    public void Configure(EntityTypeBuilder<CheckIn> builder)
    {
        builder.ToTable("CheckIns");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.ValidatedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME");
        
        builder.HasOne(x => x.Gym)
            .WithMany(x => x.CheckIns)
            .HasForeignKey(x => x.GymId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.CheckIns)
            .HasForeignKey(x => x.UserId);
    }
}
