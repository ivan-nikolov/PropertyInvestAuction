namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common.ServiceTypes;
    using Services.Models;

    public interface INeighborhoodsService : ITransient
    {
        Task CreateAsync(string name, string cityId);

        Task<IEnumerable<T>> GetByCityIdAsync<T>(string cityId);

        Task<Result> EditAsync(string id, string name);

        Task<Result> DeleteAsync(string id);

        Task<bool> CheckName(string cityId, string name);

        Task DeleteByCityIdAsync(string cityId);
    }
}
