namespace PropertyInvestAuction.Data.Common.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        Task<TEntity> GetByIdAsync(params object[] id);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
