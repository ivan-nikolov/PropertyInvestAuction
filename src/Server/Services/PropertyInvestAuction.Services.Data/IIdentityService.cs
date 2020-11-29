namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Services.Models.Identity;

    public interface IIdentityService : ITransient
    {
        string GetJwtToken(string id, string username, IEnumerable<string> roles, string secret);

        Task<IEnumerable<UserServiceModel>> GetAll(int page, int pageSize, string query);

        Task<int> GetUsersCount();
    }
}
