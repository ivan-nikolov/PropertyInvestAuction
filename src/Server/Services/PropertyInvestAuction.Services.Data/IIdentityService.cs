namespace PropertyInvestAuction.Services.Data
{
    using PropertyInvestAuction.Common.ServiceTypes;

    public interface IIdentityService : ITransient
    {
        string GetJwtToken(string userId, string userName, string secret);
    }
}
