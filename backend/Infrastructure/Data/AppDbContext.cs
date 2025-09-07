using HyrLya.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HyrLya.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : IdentityDbContext<User>(options)
    {
        public DbSet<Landlord> Landlords => Set<Landlord>();
    }
}
