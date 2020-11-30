﻿namespace PropertyInvestAuction.Server.Models.Neighborhoods
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationMessages;
    using static Common.ValidationConstants;

    public class CreateRequestModel
    {
        [Required]
        [StringLength(NeighborhoodNameMaxLength, MinimumLength = NeighborhoodNameMinLength, ErrorMessage = NeighborhoodNameLengthErrorMessage)]
        public string Name { get; set; }

        public string CityId { get; set; }
    }
}
