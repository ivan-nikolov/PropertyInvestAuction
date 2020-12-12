namespace PropertyInvestAuction.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    public interface IPropertiesService : ITransient
    {
        Task<string> CreateAsync(
            string description,
            string addressId,
            string userId,
            string categoryId,
            IEnumerable<string> photoUrls);

        Task<IEnumerable<TOutput>> GetAllAsync<TOutput, TQueryModel>(int pageSize, int pageNumber, IEnumerable<Expression<Func<TQueryModel, bool>>> filters) where TQueryModel: IMapFrom<Property>;

        Task<Result> Edit(string id, string description, string categoryId, IEnumerable<string> newPhotos);

        Task<Result> DeleteAsync(string id);

        Task<bool> IsUserAuthorized(string propertyId, string userId);
    }
}
