using Domain.Entities;
using Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
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
