namespace PropertyInvestAuction.Server.Models.Neighborhoods
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants;
    using static Common.ValidationMessages;

    public class EditRequestModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(NeighborhoodNameMaxLength, MinimumLength = NeighborhoodNameMinLength, ErrorMessage = NeighborhoodNameLengthErrorMessage)]
        public string Name { get; set; }
    }
}
