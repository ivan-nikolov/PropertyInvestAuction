namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.BidPrice)
                .HasPrecision(9, 2);

            builder.Property(b => b.Comment)
                .HasMaxLength(BidCommentMaxLength)
                .IsUnicode();

            builder.HasOne(b => b.Offer)
                .WithMany(b => b.Bids)
                .HasForeignKey(b => b.OfferId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
