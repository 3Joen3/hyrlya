using Domain.Entities;
using Infrastructure.Auth;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Landlord> Landlords => Set<Landlord>();
        public DbSet<LandlordProfile> LandlordProfiles => Set<LandlordProfile>();
        public DbSet<RentalUnit> RentalUnits => Set<RentalUnit>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new LandlordConfiguration());
            builder.ApplyConfiguration(new LandlordProfileConfiguration());
            builder.ApplyConfiguration(new RentalUnitConfiguration());
        }
    
    }
}
