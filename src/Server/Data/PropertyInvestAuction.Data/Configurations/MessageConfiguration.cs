namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .HasMaxLength(MessageTitleMaxLength)
                .IsRequired()
                .IsUnicode();

            builder.Property(m => m.Content)
                .HasMaxLength(MessageContentMaxLength)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(m => m.Sender)
                .WithMany(s => s.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Receiver)
                .WithMany(r => r.RecievedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
