using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.EF.Entities.User;
using Source.EF.Enums;

namespace Source.EF.EntityTypeConfigurations.User;

public class UserProfileTypeConfiguration : IEntityTypeConfiguration<UserProfileEntity>
{
    public void Configure(EntityTypeBuilder<UserProfileEntity> builder)
    {
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasKey(u => u.Code);
        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsUnicode(true)
               .IsRequired();

        builder.Property(e => e.CreatedOn)
               .HasDefaultValue(DateTime.UtcNow)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();

        builder.Property(u => u.Type)
               .HasDefaultValue(UserTypeEnum.Administrator);

        builder.Property(u => u.Status)
               .HasDefaultValue(UserStatusEnum.Pending);

        builder.HasMany(g => g.SessionInfomations)
               .WithOne(s => s.UserProfile)
               .HasForeignKey(s => s.UserCode)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
