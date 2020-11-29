namespace PropertyInvestAuction.Server.Models.Cities
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants;
    using static Common.ValidationMessages;

    public class EditRequestModel
    {
        public string Id { get; set; }

        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength, ErrorMessage = CityNameLengthErrorMessage)]
        public string Name { get; set; }
    }
}
