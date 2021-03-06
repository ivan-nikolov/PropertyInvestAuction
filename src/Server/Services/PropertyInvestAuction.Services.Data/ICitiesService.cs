﻿namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common.ServiceTypes;

    using Services.Models;

    public interface ICitiesService : ITransient
    {
        Task<Result> CreateAsync(string countryId, string name);

        Task<IEnumerable<T>> AllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetByCountryIdAsync<T>(string countryId);

        Task<Result> EditAsync(string id, string name);

        Task<Result> DeleteAsync(string id);

        Task<bool> CheckIfExistsAsync(string id);

        Task<bool> CheckIfNameIsTaken(string coutryId, string name);

        Task DeleteByCountryId(string countryId);
    }
}
