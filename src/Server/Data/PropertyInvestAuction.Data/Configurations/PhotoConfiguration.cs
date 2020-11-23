namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Property)
                .WithMany(p => p.Photos)
                .HasForeignKey(p => p.PropertyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
