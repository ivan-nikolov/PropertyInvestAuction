namespace PropertyInvestAuction.Server.Models.Photos
{
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    public class PhotoResponseModel : IMapFrom<PhotoDto>
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string PropertyId { get; set; }
    }
}
