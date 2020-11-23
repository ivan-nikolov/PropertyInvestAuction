namespace PropertyInvestAuction.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PropertyInvestAuction.Data.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .HasMaxLength(CategoryNameMaxLength)
                .IsRequired()
                .IsUnicode();
        }
    }
}
