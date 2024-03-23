using GymManager.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Persistence.Configurations;
public class GymConfiguration : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        builder.ToTable("Gym");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .IsRequired(false)
            .HasColumnName("Phone")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Latitude)
            .IsRequired()
            .HasColumnName("Latitude")
            .HasPrecision(10, 6);

        builder.Property(x => x.Longitude)
            .IsRequired()
            .HasColumnName("Longitude")
            .HasPrecision(10, 6);

        builder.HasMany(x => x.CheckIns)
            .WithOne(x => x.Gym);
    }
}
