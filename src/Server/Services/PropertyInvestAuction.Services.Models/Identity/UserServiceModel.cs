namespace PropertyInvestAuction.Services.Models.Identity
{
    using System.Collections.Generic;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class UserServiceModel : IMapFrom<AppUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<string> Roles { get; set; } = new HashSet<string>();
    }
}
