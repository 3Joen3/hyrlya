using HyrLya.Domain.Entities;
using HyrLya.Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HyrLya.Infrastructure.Persistence.Configurations
{
    public class LandlordConfiguration : IEntityTypeConfiguration<Landlord>
    {
        public void Configure(EntityTypeBuilder<Landlord> builder)
        {
            builder.HasIndex(l => l.IdentityId);

            builder.HasOne<AppUser>()
                .WithOne()
                .HasForeignKey<Landlord>(l => l.IdentityId)
                .IsRequired();
        }
    }
}
