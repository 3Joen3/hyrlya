using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LandlordProfileConfiguration : IEntityTypeConfiguration<LandlordProfile>
    {
        public void Configure(EntityTypeBuilder<LandlordProfile> builder)
        {
            builder.Property(p => p.ContactPhone)
                .HasConversion(
                    phone => phone != null ? phone.Value : null,
                    value => value != null ? new PhoneNumber(value) : null
                );

            builder.Property(p => p.ContactEmail)
                .HasConversion(
                    email => email != null ? email.Value : null,
                    value => value != null ? new EmailAddress(value) : null
                );

            builder.OwnsOne(p => p.Image, img =>
            {
                img.Property(i => i.Url)
                    .HasConversion(
                        url => url.Value,
                        url => new WebAddress(url)
                    )
                   .HasColumnName("ImageUrl");

                img.Property(i => i.AltText)
                    .HasColumnName("ImageAlt");
            });
        }
    }
}
