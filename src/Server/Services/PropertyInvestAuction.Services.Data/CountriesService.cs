namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using Services.Mapping;

    using static Common.ErrorMessages;
    using PropertyInvestAuction.Services.Models;

    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countryRepo;
        private readonly ICitiesService citiesService;

        public CountriesService(IDeletableEntityRepository<Country> coutryRepo, ICitiesService citiesService)
        {
            this.countryRepo = coutryRepo;
            this.citiesService = citiesService;
        }

        public async Task<bool> CheckIfExistsAsync(string id)
            => await this.countryRepo.AllAsNoTracking()
            .AnyAsync(c => c.Id == id);

        public async Task<bool> CheckIfNameIsTaken(string name)
            => await this.countryRepo.AllAsNoTracking()
            .AnyAsync(c => c.Name == name);

        public async Task<string> CreateAsync(string name)
        {
            if (this.countryRepo.AllAsNoTracking().Any(c => c.Name == name))
            {
                return CountryNameTaken;
            }

            var country = new Country
            {
                Name = name,
            };

            await this.countryRepo.AddAsync(country);
            await this.countryRepo.SaveChangesAsync();

            return country.Id;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var country = await this.countryRepo.GetByIdAsync(id);
            if (country == null)
            {
                return CountryDoesNotExists;
            }

            this.countryRepo.Delete(country);
            await this.citiesService.DeleteByCountryId(id);
            await this.countryRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(string id, string name)
        {
            var country = await this.countryRepo.GetByIdAsync(id);
            if (country == null)
            {
                return CountryDoesNotExists;
            }

            country.Name = name;
            this.countryRepo.Update(country);
            await this.countryRepo.SaveChangesAsync();

            return true;
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
