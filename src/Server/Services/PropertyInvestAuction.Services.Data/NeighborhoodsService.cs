namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;

    using Services.Mapping;
    using Services.Models;
    
    using static Common.ErrorMessages;

    public class NeighborhoodsService : INeighborhoodsService
    {
        private readonly IDeletableEntityRepository<Neighborhood> neighborhoodRepo;

        public NeighborhoodsService(IDeletableEntityRepository<Neighborhood> neighborhoodRepo)
        {
            this.neighborhoodRepo = neighborhoodRepo;
        }

        public async Task<bool> CheckName(string cityId, string name)
            => await this.neighborhoodRepo.AllAsNoTracking()
            .AnyAsync(n => n.CityId == cityId && n.Name == name);

        public async Task CreateAsync(string name, string cityId)
        {
            var neighborhood = new Neighborhood
            {
                Name = name,
                CityId = cityId,
            };

            await this.neighborhoodRepo.AddAsync(neighborhood);
            await this.neighborhoodRepo.SaveChangesAsync();
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var neighborhood = await this.neighborhoodRepo.GetByIdAsync(id);
            if (neighborhood == null)
            {
                return NeighborhoodDoesNotExists;
            }

            this.neighborhoodRepo.Delete(neighborhood);
            await this.neighborhoodRepo.SaveChangesAsync();
            return true;
        }

        public async Task<Result> EditAsync(string id, string name)
        {
            var neighborhood = await this.neighborhoodRepo.GetByIdAsync(id);
            if (neighborhood == null)
            {
                return NeighborhoodDoesNotExists;
            }

            neighborhood.Name = name;
            this.neighborhoodRepo.Update(neighborhood);
            await this.neighborhoodRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetByCityIdAsync<T>(string cityId)
            => await this.neighborhoodRepo.AllAsNoTracking()
            .Where(n => n.CityId == cityId)
            .To<T>()
            .ToListAsync();

        public async Task DeleteByCityIdAsync(string cityId)
        {
            var neighborhoods = this.neighborhoodRepo.All().Where(n => n.CityId == cityId);

            foreach (var neighborhood in neighborhoods)
            {
                this.neighborhoodRepo.Delete(neighborhood);
            }

            await this.neighborhoodRepo.SaveChangesAsync();
        }
    }
}
