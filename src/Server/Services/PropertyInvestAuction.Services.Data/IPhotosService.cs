namespace PropertyInvestAuction.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Services.Models;

    public interface IPhotosService : ITransient
    {
        Task<string> CreateAsync(string photoUrl, string propertyId);

        Task AddAllAsync(IEnumerable<string> photoUrls, string propertyId);

        Task<Result> DeleteAsync(string photoId);

        Task<Result> DeleteAllByPropertyIdAsync(string propertyId);
    }
}
