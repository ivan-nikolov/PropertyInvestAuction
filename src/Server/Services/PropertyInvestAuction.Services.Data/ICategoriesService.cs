namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Services.Models;

    public interface ICategoriesService : ITransient
    {
        Task<Result> CreateAsync(string name);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task<Result> DeleteAsync(string id);

        Task<Result> EditAsync(string id, string name);

        Task<bool> CheckIfExistsAsync(string id);

        Task<bool> CheckIfNameIsTaken(string name);
    }
}
