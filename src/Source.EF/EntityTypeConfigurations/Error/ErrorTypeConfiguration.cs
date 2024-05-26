using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.EF.Constants;
using Source.EF.Entities.Error;

namespace Source.EF.EntityTypeConfigurations.Error;

public class ErrorTypeConfiguration : IEntityTypeConfiguration<ErrorEntity>
{
    public void Configure(EntityTypeBuilder<ErrorEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();

        builder.HasData(new ErrorEntity()
        {
            Id = 1,
            Code = ErrorConst.InValidUserCodeError,
            ErrorMessage = "The user code is invalid",
            ResourceKey = "invalid_user_code",
        },
        new ErrorEntity()
        {
            Id = 400,
            Code = ErrorConst.BadRequest,
            ErrorMessage = "Bad Request",
            ResourceKey = "bad_request",
        },
        new ErrorEntity()
        {
            Id = 404,
            Code = ErrorConst.NotFound,
            ErrorMessage = "Not Found",
            ResourceKey = "not_found",
        },
        new ErrorEntity()
        {
            Id = 500,
            Code = ErrorConst.InternalServerError,
            ErrorMessage = "Internal Server Error",
            ResourceKey = "internal_server_error",
        });
    }
}
