using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.HasOne(l => l.RentalUnit)
                .WithMany()
                .HasForeignKey(l => l.RentalUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(l => l.RentalPrice, rentalPrice =>
            {
                rentalPrice.Property(r => r.Amount)
                .HasColumnName("Price");

                rentalPrice.Property(r => r.ChargeInterval)
                .HasColumnName("ChargeInterval");
            });

        }
    }
}
