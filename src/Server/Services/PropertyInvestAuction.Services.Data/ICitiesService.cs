namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common.ServiceTypes;

    using Services.Models;

    public interface ICitiesService : ITransient
    {
        Task<Result> Create(string countryId, string name);

        Task<IEnumerable<T>> All<T>();

        Task<T> GetById<T>(string id);
    }
}
