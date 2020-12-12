namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Models;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class PhotosService : IPhotosService
    {
        private readonly IRepository<Photo> photoRepo;

        public PhotosService(IRepository<Photo> photoRepo)
        {
            this.photoRepo = photoRepo;
        }

        public async Task AddAllAsync(IEnumerable<string> photoUrls, string propertyId)
        {
            foreach (var photoUrl in photoUrls)
            {
                var photo = new Photo
                {
                    Url = photoUrl,
                    PropertyId = propertyId,
                };

                await this.photoRepo.AddAsync(photo);
            }

            await this.photoRepo.SaveChangesAsync();
        }

        public async Task<string> CreateAsync(string photoUrl, string propertyId)
        {
            var photo = new Photo
            {
                Url = photoUrl,
                PropertyId = propertyId,
            };

            await this.photoRepo.AddAsync(photo);
            await this.photoRepo.SaveChangesAsync();

            return photo.Id;
        }

        public async Task<Result> DeleteAllByPropertyIdAsync(string propertyId)
        {
            var photos = await this.photoRepo.All().Where(p => p.PropertyId == propertyId).ToListAsync();

            foreach (var photo in photos)
            {
                this.photoRepo.Delete(photo);
            }

            await this.photoRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(string photoId)
        {
            var photo = await this.photoRepo.All().FirstOrDefaultAsync(p => p.Id == photoId);
            if (photo == null)
            {
                return PhotoDoesNotExists;
            }

            this.photoRepo.Delete(photo);
            await this.photoRepo.SaveChangesAsync();

            return true;
        }
    }
}
