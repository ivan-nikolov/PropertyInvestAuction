namespace PropertyInvestAuction.Services.Data
{
    using System.Threading.Tasks;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;

    using Services.Models;
    using Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    using static Common.ErrorMessages;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;

        public CitiesService(IDeletableEntityRepository<City> cityRepo)
        {
            this.cityRepo = cityRepo;
        }

        public async Task<IEnumerable<T>> AllAsync<T>()
            => await this.cityRepo.AllAsNoTracking()
            .To<T>()
            .ToListAsync();

        public async Task<bool> CheckIfExistsAsync(string id)
            => (await this.cityRepo.AllAsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id)) != null;

        public async Task<bool> CheckIfNameIsTaken(string countryId, string name)
            => await this.cityRepo.AllAsNoTracking()
            .AnyAsync(c => c.Name == name && c.CountryId == countryId);

        public async Task<Result> CreateAsync(string countryId, string name)
        {
            if (this.cityRepo.AllAsNoTracking().Any(c => c.Name == name && c.CountryId == countryId))
            {
                return CityNameTaken;
            }

            var city = new City
            {
                Name = name,
                CountryId = countryId,
            };
            
            await this.cityRepo.AddAsync(city);
            await this.cityRepo.SaveChangesAsync();
            return true;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var city = await this.cityRepo.All().FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
            {
                return CityDoesNotExists;
            }

            this.cityRepo.Delete(city);
            await this.cityRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(string id, string name)
        {
            var city = await this.cityRepo.All().FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
            {
                return CityDoesNotExists;
            }

            city.Name = name;
            this.cityRepo.Update(city);
            await this.cityRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetByCountryIdAsync<T>(string countryId)
            => await this.cityRepo.AllAsNoTracking()
            .Where(c => c.CountryId == countryId)
            .To<T>()
            .ToListAsync();


        public async Task<T> GetByIdAsync<T>(string id)
            => await this.cityRepo.AllAsNoTracking()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();
    }
}
