namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;

    using PropertyInvestAuction.Common.ServiceTypes;

    public interface IIdentityService : ITransient
    {
        string GetJwtToken(string id, string username, IEnumerable<string> roles, string secret);
    }
}
