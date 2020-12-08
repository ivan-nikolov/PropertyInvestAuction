namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Models;
    using PropertyInvestAuction.Services.Mapping;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<bool> CheckIfExistsAsync(string id)
            => await this.categoryRepo.AllAsNoTracking()
            .CountAsync(c => c.Id == id) == 1;

        public async Task<bool> CheckIfNameIsTaken(string name)
            => await this.categoryRepo.AllAsNoTracking()
            .CountAsync(c => c.Name == name) == 1;

        public async Task<Result> CreateAsync(string name)
        {
            var category = new Category
            {
                Name = name,
            };

            await this.categoryRepo.AddAsync(category);
            await this.categoryRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var category = await this.categoryRepo.All().FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return CategoryDoesNotExists;
            }

            this.categoryRepo.Delete(category);
            await this.categoryRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(string id, string name)
        {
            var category = await this.categoryRepo.All().FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return CategoryDoesNotExists;
            }

            category.Name = name;
            this.categoryRepo.Update(category);
            await this.categoryRepo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.categoryRepo.All()
            .To<T>()
            .ToListAsync();

        public async Task<T> GetByIdAsync<T>(string id)
            => await this.categoryRepo.All()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();
    }
}
