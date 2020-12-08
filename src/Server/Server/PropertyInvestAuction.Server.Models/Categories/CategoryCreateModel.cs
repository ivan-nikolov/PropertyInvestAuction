namespace PropertyInvestAuction.Server.Models.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static PropertyInvestAuction.Common.ValidationConstants;
    using static PropertyInvestAuction.Common.ValidationMessages;

    public class CategoryCreateModel
    {
        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength, ErrorMessage = NameLenghtErroMessage)]
        public string Name { get; set; }
    }
}
