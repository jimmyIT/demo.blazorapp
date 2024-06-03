using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.EF.Entities.User;

namespace Source.EF.EntityTypeConfigurations.User;

public class SessionInfomationTypeConfiguration : IEntityTypeConfiguration<SessionInfomationEntity>
{
    public void Configure(EntityTypeBuilder<SessionInfomationEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(u => u.RefreshToken).IsUnique();
        builder.Property(e => e.RefreshToken)
               .HasMaxLength(250)
               .IsRequired();

        builder.Property(e => e.CreatedOn)
               .HasDefaultValue(DateTime.UtcNow)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();

        builder.Property(e => e.Active)
               .HasDefaultValue(true);
    }
}
