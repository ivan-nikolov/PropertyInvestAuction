namespace PropertyInvestAuction.Server.Models.Identity
{
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Data.Models;
    using System.Collections.Generic;

    public class UserResponseModel : IMapFrom<AppUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsAdministrator { get; set; }

        public ICollection<string> Roles { get; set; } = new HashSet<string>();
    }
}
