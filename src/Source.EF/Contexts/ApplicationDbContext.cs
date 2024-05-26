using Microsoft.EntityFrameworkCore;
using Source.EF.Entities.Error;
using Source.EF.Entities.Parameters;
using Source.EF.Entities.User;
using Source.EF.EntityTypeConfigurations.Error;
using Source.EF.EntityTypeConfigurations.Parameters;
using Source.EF.EntityTypeConfigurations.User;

namespace Source.EF.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<SessionInfomationEntity> SessionInfomations { get; set; }
    public DbSet<ApplicationParameterEntity> ApplicationParameters { get; set; }
    public DbSet<ErrorEntity> Errors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserProfileTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SessionInfomationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationParameterTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ErrorTypeConfiguration());
    }
}
