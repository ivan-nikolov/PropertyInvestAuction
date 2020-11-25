﻿namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountryService
    {
        Task CreateAsync(string name);

        Task DeleteAsync(string id);

        Task EditAsync(string id, string name);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task<bool> CheckIfExists(string id);
    }
}
