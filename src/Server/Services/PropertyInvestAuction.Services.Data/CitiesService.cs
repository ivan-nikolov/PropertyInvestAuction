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

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;

        public CitiesService(IDeletableEntityRepository<City> cityRepo)
        {
            this.cityRepo = cityRepo;
        }

        public async Task<IEnumerable<T>> All<T>()
            => await this.cityRepo.AllAsNoTracking()
            .To<T>()
            .ToListAsync();

        public async Task<Result> Create(string countryId, string name)
        {
            var city = new City
            {
                Name = name,
                CountryId = countryId,
            };
            
            await this.cityRepo.AddAsync(city);
            await this.cityRepo.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetById<T>(string id)
            => await this.cityRepo.AllAsNoTracking()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();
    }
}
