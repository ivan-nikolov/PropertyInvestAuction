namespace PropertyInvestAuction.Server.Models.Cities
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants;
    using static Common.ValidationMessages;

    public class CreateCityRequestModel
    {
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength, ErrorMessage = StringLenghtErroMessage)]
        public string Name { get; set; }

        public string CountryId { get; set; }
    }
}
