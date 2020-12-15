namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Services.Models;

    public interface IAddressesService : ITransient
    {
        Task<T> CreateAsync<T>(string name, string cityId, string neighborhoodId);

        Task<IEnumerable<T>> GetAllAsync<T>(string cityId, string neighborhoodId);

        Task<Result> EditAsync(string id, string name);

        Task<Result> DeleteAsync(string id);

        Task<bool> CheckIfExistsAsync(string id);
    }
}
