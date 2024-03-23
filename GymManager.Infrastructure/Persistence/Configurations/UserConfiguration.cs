using GymManager.Core.Entities;
using GymManager.Core.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password");

        builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnName("Role")
            .HasDefaultValue(Role.Member);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasIndex(x => x.Email, "IX_User_Email")
            .IsUnique();

        builder
            .HasMany(x => x.CheckIns)
            .WithOne(x => x.User);
    }
}
