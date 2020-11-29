namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countryRepo;

        public CountriesService(IDeletableEntityRepository<Country> coutryRepo)
        {
            this.countryRepo = coutryRepo;
        }

        public async Task<bool> CheckIfExists(string id)
            => await this.countryRepo.AllAsNoTracking()
            .AnyAsync(c => c.Id == id);

        public async Task<string> CreateAsync(string name)
        {
            var country = new Country
            {
                Name = name,
            };

            await this.countryRepo.AddAsync(country);
            await this.countryRepo.SaveChangesAsync();

            return country.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var country = await this.countryRepo.GetByIdAsync(id);
            if (country == null)
            {
                return;
            }

            this.countryRepo.Delete(country);
            await this.countryRepo.SaveChangesAsync();
        }

        public async Task EditAsync(string id, string name)
        {
            var country = await this.countryRepo.GetByIdAsync(id);
            if (country == null)
            {
                return;
            }

            country.Name = name;
            this.countryRepo.Update(country);
            await this.countryRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.countryRepo.AllAsNoTracking()
            .To<T>()
            .ToListAsync();

        public async Task<T> GetByIdAsync<T>(string id)
            => await this.countryRepo
            .AllAsNoTracking()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

    }
}
