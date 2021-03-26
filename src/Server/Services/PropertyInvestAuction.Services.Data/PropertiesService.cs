namespace PropertyInvestAuction.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class PropertiesService : IPropertiesService
    {
        private readonly IDeletableEntityRepository<Property> propertyRepo;
        private readonly IPhotosService photosService;

        public PropertiesService(IDeletableEntityRepository<Property> propertyRepo, IPhotosService photosService)
        {
            this.propertyRepo = propertyRepo;
            this.photosService = photosService;
        }

        public async Task<string> CreateAsync(string description, string addressId, string userId, string categoryId, IEnumerable<string> photoUrls)
        {
            var property = new Property
            {
                Description = description,
                AddressId = addressId,
                UserId = userId,
                CategoryId = categoryId,
            };

            await this.propertyRepo.AddAsync(property);
            await this.propertyRepo.SaveChangesAsync();

            await this.photosService.AddAllAsync(photoUrls, property.Id);

            return property.Id;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var property = await this.propertyRepo.All().FirstOrDefaultAsync(p => p.Id == id);
            if (property == null)
            {
                return PropertyDoesNotExists;
            }

            this.propertyRepo.Delete(property);
            await this.propertyRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Edit(string id, string description, string categoryId, IEnumerable<string> newPhotos)
        {
            var property = await this.propertyRepo.All().FirstOrDefaultAsync(p => p.Id == id);
            if (property == null)
            {
                return PropertyDoesNotExists;
            }

            property.Description = description;
            property.CategoryId = categoryId;
            await this.photosService.AddAllAsync(newPhotos, property.Id);

            await this.propertyRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TOutput>> GetAllAsync<TOutput, TQueryModel>(int pageSize, int pageNumber, IEnumerable<Expression<Func<TQueryModel, bool>>> filters)
            where TQueryModel : IMapFrom<Property>
        {
            var properties = this.propertyRepo.All().To<TQueryModel>();

            foreach (var filter in filters)
            {
                properties = properties.Where(filter);
            }

            return await properties
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .To<TOutput>()
                .ToListAsync();
        }

        public async Task<bool> IsUserAuthorized(string propertyId, string userId)
            => await this.propertyRepo.AllAsNoTracking()
            .AnyAsync(p => p.Id == propertyId && p.UserId == userId);
    }
}
