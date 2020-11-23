namespace PropertyInvestAuction.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;

    using PropertyInvestAuction.Data.Common.Models;

    public class AppRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public AppRole()
            : this(null)
        {
        }

        public AppRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
