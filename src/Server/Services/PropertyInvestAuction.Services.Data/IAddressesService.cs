namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Services.Models;

    public interface IAddressesService : ITransient
    {
        Task<string> CreateAsync(string name, string cityId, string neighborhoodId);

        Task<IEnumerable<T>> GetByCityIdAsync<T>(string cityId);

        Task<Result> EditAsync(string id, string name);

        Task<Result> DeleteAsync(string id);

        Task<bool> CheckIfExistsAsync(string id);
    }
}
