namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(CategoryNameMinLength)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}
