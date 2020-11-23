namespace PropertyInvestAuction.Services.Data
{
    using System.Threading.Tasks;

    using PropertyInvestAuction.Services.Models;

    public interface IIdentityService
    {
        Task<Result<T>> RegisterAsync<T>(
            string userName,
            string email,
            string password);

        Task<Result<T>> LoginAsync<T>(string userName, string password, string secret);
    }
}
