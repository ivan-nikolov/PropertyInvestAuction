namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(CityNameMinLength)]
        public string Name { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; } = new HashSet<Neighborhood>();
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
