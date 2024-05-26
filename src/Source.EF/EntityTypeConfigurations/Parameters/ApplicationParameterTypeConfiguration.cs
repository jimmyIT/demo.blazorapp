using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.EF.Constants;
using Source.EF.Entities.Parameters;

namespace Source.EF.EntityTypeConfigurations.Parameters;

public class ApplicationParameterTypeConfiguration : IEntityTypeConfiguration<ApplicationParameterEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationParameterEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)            
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(e => e.CreatedOn)
               .HasDefaultValue(DateTime.UtcNow)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();

        builder.Property(e => e.Value)
               .HasMaxLength(250)
               .IsRequired();

        builder.Property(e => e.Description)
               .HasMaxLength(300)
               .IsRequired();

        builder.Property(e => e.Editable)
               .HasDefaultValue(false);

        builder.HasData(
            new ApplicationParameterEntity()
            { 
                Id = 1,
                Code = ApplicationParameterConst.EmailAddressRegex,
                Value = "\\w+([-!#$%&‘*'+–/=?^_{1}`.{|}~]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
                Description = "Email address regex",
                Editable = true,
            },
            new ApplicationParameterEntity()
            {
                Id = 2,
                Code = ApplicationParameterConst.PasswordStrength,
                Value = "^.*(?=.{8,12})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\d]).*$",
                Description = "Password strength",
                Editable = true,
            },
            new ApplicationParameterEntity()
            {
                Id = 3,
                Code = ApplicationParameterConst.UseSecurityPin,
                Value = "false",
                Description = "Use security pin",
                Editable = true,
            },
            new ApplicationParameterEntity()
            {
                Id = 4,
                Code = ApplicationParameterConst.AutoGenerateUserCode,
                Value = "false",
                Description = "Auto generate the user code when creating",
                Editable = true,
            });
    }
}
