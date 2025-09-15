using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class RentalUnitConfiguration : IEntityTypeConfiguration<RentalUnit>
    {
        public void Configure(EntityTypeBuilder<RentalUnit> builder)
        {
            builder.OwnsMany(r => r.Images, img =>
            {
                img.WithOwner().HasForeignKey("RentalUnitId");
                img.ToTable("RentalUnitImages");

                img.Property(i => i.Url)
                    .HasConversion(
                        url => url.Value,
                        value => new WebAddress(value)
                    )
                    .HasColumnName("Url");

                img.Property(i => i.AltText)
                    .HasColumnName("AltText");
            });

            builder.OwnsOne(r => r.Address, address =>
            {
                address.Property(a => a.Street)
                    .HasColumnName("Street");

                address.Property(a => a.HouseNumber)
                    .HasColumnName("HouseNumber");

                address.Property(a => a.City)
                    .HasColumnName("City");
            });
        }
    }
}
