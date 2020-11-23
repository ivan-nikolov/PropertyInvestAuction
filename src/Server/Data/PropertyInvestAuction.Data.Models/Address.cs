namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(AddressNameMinLength)]
        public string Name { get; set; }

        public string NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }

        public string CityId { get; set; }
        public City City { get; set; }

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}
