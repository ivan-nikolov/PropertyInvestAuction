namespace PropertyInvestAuction.Server.Models.Neighborhoods
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationMessages;
    using static Common.ValidationConstants;

    public class NeighborhoodCreateRequestModel
    {
        [Required]
        [StringLength(NeighborhoodNameMaxLength, MinimumLength = NeighborhoodNameMinLength, ErrorMessage = StringLenghtErroMessage)]
        public string Name { get; set; }

        public string CityId { get; set; }
    }
}
