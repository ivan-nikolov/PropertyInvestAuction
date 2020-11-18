namespace PropertyInvestAuction.Services.Data
{
    using System.Threading.Tasks;

    using PropertyInvestAuction.Services.Models;

    public interface IIdentityService
    {
        Task<Result> RegisterAsync(
            string userName,
            string email,
            string password);

        Task<Result> LoginAsync(string userName, string password, string secret);
    }
}
