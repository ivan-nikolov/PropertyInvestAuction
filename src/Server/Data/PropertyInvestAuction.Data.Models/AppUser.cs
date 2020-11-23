namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using PropertyInvestAuction.Data.Common.Models;

    public class AppUser : IdentityUser<string>, IAuditInfo, IDeletableEntity
    {
        public AppUser()
            => this.Id = Guid.NewGuid().ToString();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Message> RecievedMessages { get; set; } = new HashSet<Message>();
        public ICollection<Message> SentMessages { get; set; } = new HashSet<Message>();

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();

        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();

        public ICollection<Bid> Bids { get; set; } = new HashSet<Bid>();
    } 
}
