namespace PropertyInvestAuction.Server.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    using static PropertyInvestAuction.Common.ValidationConstants;
    using static PropertyInvestAuction.Common.ValidationMessages;

    public class CountryEditModel
    {
        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength, ErrorMessage = NameLenghtErroMessage)]
        public string Name { get; set; }
    }
}
