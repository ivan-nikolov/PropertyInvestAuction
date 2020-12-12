namespace PropertyInvestAuction.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            using var reader = new MemoryStream();
            await file.CopyToAsync(reader);
            var fileBites = reader.ToArray();

            using var stream = new MemoryStream(fileBites);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.AbsoluteUri;
        }

        public async Task<IEnumerable<string>> UploadFilesAsync(IEnumerable<IFormFile> files)
        {
            var imageUrls = new List<string>();
            foreach (var file in files)
            {
                var result = await this.UploadAsync(file);
                imageUrls.Add(result);
            }

            return imageUrls;
        }
    }
}
