namespace PropertyInvestAuction.Server.Models.Country
{
    using System.ComponentModel.DataAnnotations;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class CreateInputModel
    {
        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        public string Name { get; set; }
    }
}
