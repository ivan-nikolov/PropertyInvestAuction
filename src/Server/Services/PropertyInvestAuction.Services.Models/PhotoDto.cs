namespace PropertyInvestAuction.Services.Models
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class PhotoDto : IMapFrom<Photo>
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string PropertyId { get; set; }
    }
}
