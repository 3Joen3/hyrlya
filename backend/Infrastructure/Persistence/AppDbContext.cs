using HyrLya.Domain.Entities;
using HyrLya.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HyrLya.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Landlord> Landlords => Set<Landlord>();
    }
}
