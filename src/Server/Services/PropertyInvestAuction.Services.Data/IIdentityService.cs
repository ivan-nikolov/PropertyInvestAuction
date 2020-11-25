namespace PropertyInvestAuction.Services.Data
{
    public interface IIdentityService
    {
        string GetJwtToken(string userId, string userName, string secret);
    }
}
