namespace PropertyInvestAuction.Server.Models.Identity
{
    public class LoginResponseModel
    {
        public string Token { get; set; }

        public string[] Roles { get; set; }
    }
}
