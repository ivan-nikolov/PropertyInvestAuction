﻿namespace PropertyInvestAuction.Server.Models.Neighborhoods
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants;
    using static Common.ValidationMessages;

    public class NeighborhoodEditRequestModel
    {
        [Required]
        [StringLength(NeighborhoodNameMaxLength, MinimumLength = NeighborhoodNameMinLength, ErrorMessage = StringLenghtErroMessage)]
        public string Name { get; set; }
    }
}
