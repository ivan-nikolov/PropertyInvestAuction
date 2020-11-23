namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static PropertyInvestAuction.Common.ValidationConstants;
    using PropertyInvestAuction.Data.Models;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .HasMaxLength(AddressNameMaxLength)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(a => a.Neighborhood)
                .WithMany(n => n.Addresses)
                .HasForeignKey(a => a.NeighborhoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
