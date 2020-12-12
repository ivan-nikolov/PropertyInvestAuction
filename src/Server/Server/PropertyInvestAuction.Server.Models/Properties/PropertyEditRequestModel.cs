namespace PropertyInvestAuction.Server.Models.Properties
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    using static PropertyInvestAuction.Common.ValidationConstants;
    using static PropertyInvestAuction.Common.ValidationMessages;
    using System.ComponentModel.DataAnnotations;

    public class PropertyEditRequestModel
    {
        [StringLength(PropertyDescriptionMaxLength, MinimumLength = PropertyDescriptionMinLength, ErrorMessage = StringLenghtErroMessage)]
        public string Description { get; set; }

        public IEnumerable<IFormFile> Photos { get; set; }

        public string CategoryId { get; set; }
    }
}
