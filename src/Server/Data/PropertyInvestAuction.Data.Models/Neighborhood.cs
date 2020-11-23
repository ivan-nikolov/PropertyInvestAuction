namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;

    using PropertyInvestAuction.Data.Common.Models;

    public class Neighborhood : BaseDeletableModel<string>
    {
        public Neighborhood()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string CityId { get; set; }
        public City City { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
