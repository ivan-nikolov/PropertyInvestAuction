namespace PropertyInvestAuction.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using PropertyInvestAuction.Common.ServiceTypes;

    public interface ICloudinaryService : ITransient
    {
        Task<string> UploadAsync(IFormFile file);

        Task<IEnumerable<string>> UploadFilesAsync(IEnumerable<IFormFile> files);
    }
}
