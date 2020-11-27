namespace PropertyInvestAuction.Server.Models.Identity
{
    using System.Collections.Generic;

    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models.Identity;

    public class LoginResponseModel : IMapFrom<LoginModel>
    {
        public string Token { get; set; }
    }
}
