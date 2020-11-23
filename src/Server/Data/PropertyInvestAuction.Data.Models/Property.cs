namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Property : BaseDeletableModel<string>
    {
        public Property()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(PropertyDescriptionMinLength)]
        public string Description { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();

        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}
