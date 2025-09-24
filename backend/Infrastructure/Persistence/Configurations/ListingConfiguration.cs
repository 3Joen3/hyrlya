using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.OwnsOne(l => l.RentalPeriod, rentalPeriod =>
            {
                rentalPeriod.Property(r => r.StartDate)
                .HasColumnName("RentalStartDate");

                rentalPeriod.Property(r => r.EndDate)
                .HasColumnName("RentalEndDate");
            });
        }
    }
}
