namespace PropertyInvestAuction.Server.Models.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using static PropertyInvestAuction.Common.ValidationConstants;
    using static PropertyInvestAuction.Common.ValidationMessages;

    public class AddressCreateModel
    {
        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength, ErrorMessage = StringLenghtErroMessage)]
        public string Name { get; set; }

        public string CityId { get; set; }

        public string NeighborhoodId { get; set; }
    }
}
