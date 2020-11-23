namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
    {
        public void Configure(EntityTypeBuilder<Neighborhood> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Name)
                .HasMaxLength(NeighborhoodNameMaxLength)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(n => n.City)
                .WithMany(n => n.Neighborhoods)
                .HasForeignKey(n => n.CityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
