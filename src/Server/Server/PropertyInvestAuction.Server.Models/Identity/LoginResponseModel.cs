namespace PropertyInvestAuction.Server.Models.Identity
{
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models.Identity;

    public class LoginResponseModel : IMapFrom<LoginModel>
    {
        public string Token { get; set; }

        public string[] Roles { get; set; }
    }
}
