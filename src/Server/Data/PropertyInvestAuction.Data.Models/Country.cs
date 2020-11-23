namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Country : BaseDeletableModel<string>
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(CountryNameMinLength)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
