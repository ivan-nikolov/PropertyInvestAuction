namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .HasMaxLength(CityNameMaxLength)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
