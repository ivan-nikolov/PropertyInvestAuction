namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class AddressesService : IAddressesService
    {
        private readonly IDeletableEntityRepository<Address> addressRepo;

        public AddressesService(IDeletableEntityRepository<Address> addressRepo)
        {
            this.addressRepo = addressRepo;
        }

        public async Task<bool> CheckIfExistsAsync(string id)
            => await this.addressRepo.AllAsNoTracking()
            .AnyAsync(a => a.Id == id);

        public async Task<string> CreateAsync(string name, string cityId, string neighborhoodId)
        {
            var addresss = new Address
            {
                Name = name,
                CityId = cityId,
                NeighborhoodId = neighborhoodId,
            };

            await this.addressRepo.AddAsync(addresss);
            await this.addressRepo.SaveChangesAsync();

            return addresss.Id;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var address = await this.addressRepo.All().FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                return AddressDoesNotExists;
            }

            this.addressRepo.Delete(address);
            await this.addressRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(string id, string name)
        {
            var address = await this.addressRepo.All().FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                return AddressDoesNotExists;
            }

            address.Name = name;
            this.addressRepo.Update(address);
            await this.addressRepo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetByCityIdAsync<T>(string cityId)
            => await this.addressRepo.AllAsNoTracking()
            .Where(a => a.CityId == cityId)
            .To<T>()
            .ToListAsync();
    }
}
